namespace AscadWeb.Api.Infrastructure;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TenantContext tenantContext)
    {
        var tenantClaim = context.User.FindFirst("TenantId");
        if (tenantClaim is not null && Guid.TryParse(tenantClaim.Value, out var tenantId))
        {
            tenantContext.TenantId = tenantId;
        }

        await _next(context);
    }
}
