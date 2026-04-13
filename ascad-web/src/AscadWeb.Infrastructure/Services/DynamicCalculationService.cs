using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NCalc2;

namespace AscadWeb.Infrastructure.Services;

/// <summary>
/// Database-driven calculation engine that mirrors the original desktop hesaplamalar.cs approach.
/// Reads CalculationDefinition rows from DB and evaluates them dynamically using NCalc.
/// </summary>
public class DynamicCalculationService : IDynamicCalculationService
{
    private readonly AscadDbContext _db;
    private readonly IServiceProvider _serviceProvider;

    public DynamicCalculationService(AscadDbContext db, IServiceProvider serviceProvider)
    {
        _db = db;
        _serviceProvider = serviceProvider;
    }

    public async Task<List<CalculationResult>> ExecuteCalculationsAsync(Lift lift, Guid tenantId)
    {
        // 1. Read CalculationDefinition rows from DB
        var definitions = await _db.CalculationDefinitions
            .Where(d => d.TenantId == tenantId && d.IsActive)
            .Where(d => (d.TipKodu == null || d.TipKodu == "TEMEL" || d.TipKodu == lift.AsansorTipiKodu.ToString()))
            .Where(d => (d.TahrikKodu == null || d.TahrikKodu == "TEMEL" || d.TahrikKodu == lift.TahrikKodu.ToString()))
            .Where(d => (d.YonKodu == null || d.YonKodu == "TEMEL" || d.YonKodu == lift.YonKodu.ToString()))
            .OrderBy(d => d.Sira)
            .ToListAsync();

        // 2. If no definitions found, fall back to existing hardcoded CalculationService
        if (definitions.Count == 0)
        {
            var calculationService = _serviceProvider.GetRequiredService<ICalculationService>();
            return await calculationService.RunCalculationsAsync(lift);
        }

        // 3. Build initial parameter dictionary from Lift properties
        var parameters = BuildParameterDictionary(lift);
        var results = new List<CalculationResult>();

        // 4. Process each definition
        foreach (var definition in definitions)
        {
            try
            {
                var result = await ProcessDefinition(definition, parameters, lift);
                results.Add(result);

                // Accumulate successful results into parameter dictionary
                if (result.FormulSonuc != "ERR")
                {
                    AddParameter(parameters, definition.Parametre, result.FormulSonuc, definition.VeriTipi);
                }
            }
            catch (Exception)
            {
                // On any error, create error result and continue
                results.Add(CreateErrorResult(lift.Id, definition, "Beklenmeyen hata"));
            }
        }

        return results;
    }

    private async Task<CalculationResult> ProcessDefinition(
        CalculationDefinition definition,
        Dictionary<string, object> parameters,
        Lift lift)
    {
        var standart = definition.Standart;

        if (standart == "GENEL")
        {
            return ProcessGenel(definition, parameters, lift);
        }
        else if (standart == "GENELFRM")
        {
            return ProcessGenelFrm(definition, parameters, lift);
        }
        else if (standart == "SORG")
        {
            return ProcessSorg(definition, parameters, lift);
        }
        else if (standart.Contains('-'))
        {
            return await ProcessMasterLookup(definition, parameters, lift);
        }
        else
        {
            return CreateErrorResult(lift.Id, definition, $"Bilinmeyen standart tipi: {standart}");
        }
    }

    /// <summary>
    /// GENEL: Direct parameter lookup from the lift's properties or parameter dictionary.
    /// </summary>
    private CalculationResult ProcessGenel(
        CalculationDefinition definition,
        Dictionary<string, object> parameters,
        Lift lift)
    {
        // Try to find the parameter value from the existing parameter dictionary first
        if (parameters.TryGetValue(definition.Parametre, out var value))
        {
            return new CalculationResult
            {
                LiftId = lift.Id,
                Sira = definition.Sira,
                Parametre = definition.Parametre,
                Standart = definition.Standart,
                Aciklama = definition.Aciklama,
                Formul = definition.Formul,
                FormulDeger = "",
                FormulSonuc = value.ToString() ?? "",
                Birim = definition.Birim,
                VeriTipi = definition.VeriTipi
            };
        }

        return CreateErrorResult(lift.Id, definition, $"Parametre bulunamadı: {definition.Parametre}");
    }

    /// <summary>
    /// GENELFRM: Evaluate NCalc formula with parameter substitution.
    /// Mirrors the original hesaplamalar.cs GENELFRM logic.
    /// </summary>
    private CalculationResult ProcessGenelFrm(
        CalculationDefinition definition,
        Dictionary<string, object> parameters,
        Lift lift)
    {
        try
        {
            var expression = new Expression(definition.Formul);
            foreach (var param in parameters)
            {
                expression.Parameters[param.Key] = param.Value;
            }

            // Evaluate to get the result
            var result = expression.Evaluate();

            // Build substituted formula string
            var substituted = BuildSubstitutedFormula(expression, parameters);

            return new CalculationResult
            {
                LiftId = lift.Id,
                Sira = definition.Sira,
                Parametre = definition.Parametre,
                Standart = definition.Standart,
                Aciklama = definition.Aciklama,
                Formul = definition.Formul,
                FormulDeger = substituted,
                FormulSonuc = result?.ToString() ?? "0",
                Birim = definition.Birim,
                VeriTipi = definition.VeriTipi
            };
        }
        catch (Exception ex)
        {
            return CreateErrorResult(lift.Id, definition, ex.Message);
        }
    }

    /// <summary>
    /// SORG: Conditional evaluation returning "UY" (compliant) or "UD" (non-compliant).
    /// Wraps the formula in if(formula, 'UY', 'UD') — mirrors original hesaplamalar.cs SORG logic.
    /// </summary>
    private CalculationResult ProcessSorg(
        CalculationDefinition definition,
        Dictionary<string, object> parameters,
        Lift lift)
    {
        try
        {
            var wrappedFormula = $"if({definition.Formul}, 'UY', 'UD')";
            var expression = new Expression(wrappedFormula);
            foreach (var param in parameters)
            {
                expression.Parameters[param.Key] = param.Value;
            }

            var result = expression.Evaluate();

            // Build substituted formula for display (without the if wrapper)
            var substituted = BuildSubstitutedFormula(new Expression(definition.Formul) { Parameters = expression.Parameters }, parameters);

            return new CalculationResult
            {
                LiftId = lift.Id,
                Sira = definition.Sira,
                Parametre = definition.Parametre,
                Standart = definition.Standart,
                Aciklama = definition.Aciklama,
                Formul = definition.Formul,
                FormulDeger = substituted,
                FormulSonuc = result?.ToString() ?? "ERR",
                Birim = definition.Birim,
                VeriTipi = definition.VeriTipi
            };
        }
        catch (Exception ex)
        {
            return CreateErrorResult(lift.Id, definition, ex.Message);
        }
    }

    /// <summary>
    /// Hyphen-separated standart (e.g., "ray-KabinRAYID"): Look up from ProductCatalog.
    /// Split on '-', first part is the category/table, second part is the FK parameter name.
    /// </summary>
    private async Task<CalculationResult> ProcessMasterLookup(
        CalculationDefinition definition,
        Dictionary<string, object> parameters,
        Lift lift)
    {
        try
        {
            var parts = definition.Standart.Split('-');
            if (parts.Length < 2)
            {
                return CreateErrorResult(lift.Id, definition, "Geçersiz master lookup formatı");
            }

            var category = parts[0];
            var fkParam = parts[1];

            // Find the FK value from parameters (case-insensitive)
            var lookupKey = category + fkParam;
            var fkValue = parameters
                .FirstOrDefault(x => string.Equals(x.Key, lookupKey, StringComparison.OrdinalIgnoreCase))
                .Value;

            if (fkValue == null)
            {
                return CreateErrorResult(lift.Id, definition, $"FK parametre bulunamadı: {lookupKey}");
            }

            // Look up from ProductCatalog via IProductCatalogService
            var catalogService = _serviceProvider.GetService<IProductCatalogService>();
            if (catalogService == null)
            {
                return CreateErrorResult(lift.Id, definition, "ProductCatalogService bulunamadı");
            }

            // Search by category and model name matching the FK value
            var items = await catalogService.SearchAsync(category, fkValue.ToString(), lift.Project?.TenantId ?? Guid.Empty);

            if (items == null || items.Count == 0)
            {
                return CreateErrorResult(lift.Id, definition, $"Katalog kaydı bulunamadı: {category}/{fkValue}");
            }

            // Extract the requested parameter from the catalog item's SpecsJson
            var item = items.First();
            var specValue = ExtractSpecValue(item.SpecsJson, definition.Parametre);

            return new CalculationResult
            {
                LiftId = lift.Id,
                Sira = definition.Sira,
                Parametre = definition.Parametre,
                Standart = definition.Standart,
                Aciklama = definition.Aciklama,
                Formul = definition.Formul,
                FormulDeger = $"{category}[{fkValue}].{definition.Parametre}",
                FormulSonuc = specValue ?? "ERR",
                Birim = definition.Birim,
                VeriTipi = definition.VeriTipi
            };
        }
        catch (Exception ex)
        {
            return CreateErrorResult(lift.Id, definition, ex.Message);
        }
    }

    /// <summary>
    /// Extract a value from a JSON specs string by property name.
    /// </summary>
    private static string? ExtractSpecValue(string specsJson, string propertyName)
    {
        try
        {
            var doc = System.Text.Json.JsonDocument.Parse(specsJson);
            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                if (string.Equals(prop.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    return prop.Value.ToString();
                }
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Build a parameter dictionary from the Lift entity's properties.
    /// This provides the initial set of parameters available to formulas.
    /// </summary>
    private static Dictionary<string, object> BuildParameterDictionary(Lift lift)
    {
        var parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
        {
            ["KuyuGen"] = (decimal)lift.KuyuGenisligi,
            ["KuyuDer"] = (decimal)lift.KuyuDerinligi,
            ["KuyuDibi"] = (decimal)lift.KuyuDibi,
            ["KuyuKafa"] = (decimal)lift.KuyuKafa,
            ["KabinGen"] = (decimal)lift.KabinGenisligi,
            ["KabinDer"] = (decimal)lift.KabinDerinligi,
            ["KabinYuk"] = (decimal)lift.KabinYuksekligi,
            ["KapiGen"] = (decimal)lift.KapiGenisligi,
            ["BeyanYuk"] = (decimal)lift.BeyanYuk,
            ["BeyanKisi"] = (decimal)lift.BeyanKisi,
            ["DurakSayisi"] = (decimal)lift.DurakSayisi,
            ["KatYuksekligi"] = decimal.TryParse(lift.KatYuksekligi, out var ky) ? ky : 3000m,
            ["RatedSpeed"] = (decimal)lift.RatedSpeed,
            ["BalanceRatio"] = (decimal)lift.BalanceRatio,
            ["AsansorTipiKodu"] = lift.AsansorTipiKodu.ToString(),
            ["TahrikKodu"] = lift.TahrikKodu.ToString(),
            ["YonKodu"] = lift.YonKodu.ToString(),
            ["KabinRayStr"] = lift.KabinRayStr,
            ["AgrRayStr"] = lift.AgrRayStr,
            ["KabinTamponu"] = lift.KabinTamponu,
            ["AgrTamponu"] = lift.AgrTamponu,
            ["KapiTipi"] = lift.KapiTipi,
        };

        // Add roping factor based on drive type
        parameters["RopingFactor"] = lift.TahrikKodu == Core.Enums.TahrikKodu.YA ? 2m : 1m;

        return parameters;
    }

    /// <summary>
    /// Add a computed result to the parameter dictionary for use by subsequent formulas.
    /// </summary>
    private static void AddParameter(Dictionary<string, object> parameters, string name, string value, string veriTipi)
    {
        if (veriTipi == "d")
        {
            if (decimal.TryParse(value, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out var numericValue))
            {
                parameters[name] = numericValue;
            }
            else
            {
                parameters[name] = value;
            }
        }
        else
        {
            parameters[name] = value;
        }
    }

    /// <summary>
    /// Build a substituted formula string by replacing parameter references with their values.
    /// Mirrors the original hesaplamalar.cs approach.
    /// </summary>
    private static string BuildSubstitutedFormula(Expression expression, Dictionary<string, object> parameters)
    {
        try
        {
            var parsed = expression.ParsedExpression?.ToString() ?? expression.ToString() ?? "";
            foreach (var param in parameters)
            {
                var placeholder = $"([{param.Key}])";
                parsed = parsed.Replace(placeholder, param.Value?.ToString() ?? "");
            }
            return parsed;
        }
        catch
        {
            return expression.ToString() ?? "";
        }
    }

    /// <summary>
    /// Create an error CalculationResult with FormulSonuc = "ERR".
    /// </summary>
    private static CalculationResult CreateErrorResult(Guid liftId, CalculationDefinition definition, string errorMessage)
    {
        return new CalculationResult
        {
            LiftId = liftId,
            Sira = definition.Sira,
            Parametre = definition.Parametre,
            Standart = definition.Standart,
            Aciklama = $"{definition.Aciklama} [HATA: {errorMessage}]",
            Formul = definition.Formul,
            FormulDeger = "",
            FormulSonuc = "ERR",
            Birim = definition.Birim,
            VeriTipi = definition.VeriTipi
        };
    }
}
