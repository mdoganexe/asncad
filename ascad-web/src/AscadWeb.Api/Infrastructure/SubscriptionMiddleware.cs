using System.Text.Json;
using AscadWeb.Core.Exceptions;
using AscadWeb.Core.Interfaces;

namespace AscadWeb.Api.Infrastructure;

public class SubscriptionMiddleware
{
    private readonly RequestDelegate _next;

    public SubscriptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Skip if not authenticated (no TenantId available)
        var tenantContext = context.RequestServices.GetService<TenantContext>();
        if (tenantContext is null || tenantContext.TenantId == Guid.Empty)
        {
            await _next(context);
            return;
        }

        // Only check write operations
        var method = context.Request.Method;
        if (!HttpMethods.IsPost(method) && !HttpMethods.IsPut(method) && !HttpMethods.IsDelete(method))
        {
            await _next(context);
            return;
        }

        // Gracefully skip if ISubscriptionService is not yet registered
        var subscriptionService = context.RequestServices.GetService<ISubscriptionService>();
        if (subscriptionService is null)
        {
            await _next(context);
            return;
        }

        var path = context.Request.Path.Value ?? string.Empty;
        var tenantId = tenantContext.TenantId;

        try
        {
            // Check specific routes for plan limits
            if (HttpMethods.IsPost(method) && path.Equals("/api/projects", StringComparison.OrdinalIgnoreCase))
            {
                try { await subscriptionService.EnforceProjectLimitAsync(tenantId); }
                catch (Exception) { /* Skip enforcement on error */ }
            }
            else if (HttpMethods.IsPost(method) && path.EndsWith("/report", StringComparison.OrdinalIgnoreCase)
                     && path.StartsWith("/api/lifts/", StringComparison.OrdinalIgnoreCase))
            {
                try { await subscriptionService.EnforceExportLimitAsync(tenantId); }
                catch (Exception) { /* Skip enforcement on error */ }
            }
        }
        catch (PlanLimitExceededException ex)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                error = new
                {
                    code = "PLAN_LIMIT_EXCEEDED",
                    message = ex.Message
                }
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
            return;
        }

        await _next(context);
    }
}
