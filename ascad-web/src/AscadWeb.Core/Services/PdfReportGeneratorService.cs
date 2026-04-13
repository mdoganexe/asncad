using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AscadWeb.Core.Services;

public class PdfReportGeneratorService : IPdfReportGeneratorService
{
    public Task<byte[]> GenerateCalculationReportAsync(Lift lift, CompanyInfo? companyInfo, Project project)
    {
        var reportId = Guid.NewGuid();
        var generationDate = DateTime.UtcNow;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.MarginHorizontal(30);
                page.MarginVertical(25);
                page.DefaultTextStyle(x => x.FontSize(9));

                page.Header().Element(header => ComposeHeader(header, companyInfo, project, reportId, generationDate));
                page.Content().Element(content => ComposeContent(content, lift));
                page.Footer().Element(footer => ComposeFooter(footer, companyInfo));
            });
        });

        var bytes = document.GeneratePdf();
        return Task.FromResult(bytes);
    }

    private static void ComposeHeader(IContainer container, CompanyInfo? ci, Project project, Guid reportId, DateTime date)
    {
        container.Column(col =>
        {
            // Company letterhead
            col.Item().Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text(ci?.Ad ?? "Firma Adı").Bold().FontSize(14);
                    if (!string.IsNullOrEmpty(ci?.Adres))
                        c.Item().Text(ci.Adres).FontSize(8);
                    var contactParts = new List<string>();
                    if (!string.IsNullOrEmpty(ci?.Telefon)) contactParts.Add($"Tel: {ci.Telefon}");
                    if (!string.IsNullOrEmpty(ci?.Email)) contactParts.Add($"E-posta: {ci.Email}");
                    if (contactParts.Count > 0)
                        c.Item().Text(string.Join(" | ", contactParts)).FontSize(8);
                });
            });

            col.Item().PaddingVertical(5).LineHorizontal(1);

            // Project info
            col.Item().Row(row =>
            {
                row.RelativeItem().Text($"Proje: {project.ProjectName}").Bold().FontSize(11);
                row.ConstantItem(150).AlignRight().Text($"Tarih: {date:dd.MM.yyyy}").FontSize(9);
            });

            col.Item().Text($"Rapor No: {reportId}").FontSize(8).FontColor(Colors.Grey.Medium);
            col.Item().PaddingBottom(8);
        });
    }

    private static void ComposeContent(IContainer container, Lift lift)
    {
        container.Column(col =>
        {
            // Lift configuration table
            col.Item().Text("Asansör Konfigürasyonu").Bold().FontSize(11);
            col.Item().PaddingBottom(4);
            col.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(3);
                });

                AddConfigRow(table, "Asansör Tipi", lift.AsansorTipiKodu.ToString());
                AddConfigRow(table, "Tahrik", lift.TahrikKodu.ToString());
                AddConfigRow(table, "Yön", lift.YonKodu.ToString());
                AddConfigRow(table, "Kuyu Genişliği", $"{lift.KuyuGenisligi} mm");
                AddConfigRow(table, "Kuyu Derinliği", $"{lift.KuyuDerinligi} mm");
                AddConfigRow(table, "Kabin Genişliği", $"{lift.KabinGenisligi} mm");
                AddConfigRow(table, "Kabin Derinliği", $"{lift.KabinDerinligi} mm");
                AddConfigRow(table, "Beyan Yük", $"{lift.BeyanYuk} kg");
                AddConfigRow(table, "Beyan Kişi", $"{lift.BeyanKisi}");
                AddConfigRow(table, "Hız", $"{lift.RatedSpeed} m/s");
            });

            col.Item().PaddingVertical(10);

            // Calculation results table
            var results = lift.CalculationResults?.OrderBy(r => r.Sira).ToList();
            if (results != null && results.Count > 0)
            {
                col.Item().Text("Hesaplama Sonuçları").Bold().FontSize(11);
                col.Item().PaddingBottom(4);
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(30);  // Sıra
                        columns.RelativeColumn(2);    // Parametre
                        columns.RelativeColumn(3);    // Açıklama
                        columns.RelativeColumn(2);    // Formül
                        columns.RelativeColumn(1.5f); // Sonuç
                        columns.ConstantColumn(35);   // Birim
                        columns.ConstantColumn(30);   // Durum
                    });

                    // Header
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Sıra").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Parametre").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Açıklama").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Formül").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Sonuç").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Birim").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Durum").Bold().FontSize(8);
                    });

                    foreach (var r in results)
                    {
                        var isUd = r.FormulSonuc == "UD";
                        var bgColor = isUd ? Colors.Red.Lighten4 : Colors.White;

                        // Determine status display
                        var durum = r.Standart == "SORG" ? r.FormulSonuc : "-";

                        table.Cell().Background(bgColor).Padding(2).Text(r.Sira.ToString()).FontSize(7);
                        table.Cell().Background(bgColor).Padding(2).Text(r.Parametre).FontSize(7);
                        table.Cell().Background(bgColor).Padding(2).Text(r.Aciklama).FontSize(7);
                        table.Cell().Background(bgColor).Padding(2).Text(r.FormulDeger).FontSize(7);
                        table.Cell().Background(bgColor).Padding(2).Text(r.FormulSonuc).FontSize(7);
                        table.Cell().Background(bgColor).Padding(2).Text(r.Birim).FontSize(7);
                        table.Cell().Background(bgColor).Padding(2).Text(durum).FontSize(7);
                    }
                });
            }

            col.Item().PaddingVertical(10);

            // Floor information table
            var floors = lift.Floors?.OrderBy(f => f.KatNo).ToList();
            if (floors != null && floors.Count > 0)
            {
                col.Item().Text("Kat Bilgileri").Bold().FontSize(11);
                col.Item().PaddingBottom(4);
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Kat No").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Rumuz").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Yükseklik (mm)").Bold().FontSize(8);
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Mimari Kot").Bold().FontSize(8);
                    });

                    foreach (var f in floors)
                    {
                        table.Cell().Padding(2).Text(f.KatNo.ToString()).FontSize(8);
                        table.Cell().Padding(2).Text(f.KatRumuz).FontSize(8);
                        table.Cell().Padding(2).Text(f.KatYuksekligi.ToString()).FontSize(8);
                        table.Cell().Padding(2).Text(f.MimariKot).FontSize(8);
                    }
                });
            }
        });
    }

    private static void ComposeFooter(IContainer container, CompanyInfo? ci)
    {
        container.Column(col =>
        {
            col.Item().LineHorizontal(0.5f);
            col.Item().PaddingTop(4);

            if (ci != null)
            {
                col.Item().Row(row =>
                {
                    // Mechanical engineer
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Makina Mühendisi").Bold().FontSize(8);
                        if (!string.IsNullOrEmpty(ci.MakinaMuhAd))
                            c.Item().Text(ci.MakinaMuhAd).FontSize(8);
                        if (!string.IsNullOrEmpty(ci.MakinaMuhOdaSicil))
                            c.Item().Text($"Oda Sicil: {ci.MakinaMuhOdaSicil}").FontSize(7);
                        if (!string.IsNullOrEmpty(ci.MakinaMuhBelge))
                            c.Item().Text($"Belge: {ci.MakinaMuhBelge}").FontSize(7);
                        if (!string.IsNullOrEmpty(ci.MakinaMuhSMM))
                            c.Item().Text($"SMM: {ci.MakinaMuhSMM}").FontSize(7);
                    });

                    // Electrical engineer
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Elektrik Mühendisi").Bold().FontSize(8);
                        if (!string.IsNullOrEmpty(ci.ElektrikMuhAd))
                            c.Item().Text(ci.ElektrikMuhAd).FontSize(8);
                        if (!string.IsNullOrEmpty(ci.ElektrikMuhOdaSicil))
                            c.Item().Text($"Oda Sicil: {ci.ElektrikMuhOdaSicil}").FontSize(7);
                        if (!string.IsNullOrEmpty(ci.ElektrikMuhBelge))
                            c.Item().Text($"Belge: {ci.ElektrikMuhBelge}").FontSize(7);
                        if (!string.IsNullOrEmpty(ci.ElektrikMuhSMM))
                            c.Item().Text($"SMM: {ci.ElektrikMuhSMM}").FontSize(7);
                    });
                });
            }

            col.Item().AlignRight().Text(text =>
            {
                text.Span("Sayfa ").FontSize(7);
                text.CurrentPageNumber().FontSize(7);
                text.Span(" / ").FontSize(7);
                text.TotalPages().FontSize(7);
            });
        });
    }

    private static void AddConfigRow(TableDescriptor table, string label, string value)
    {
        table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(label).FontSize(9);
        table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(value).FontSize(9);
    }
}
