using AscadWeb.Core.Interfaces;

namespace AscadWeb.Api.Infrastructure;

public class TenantContext : ITenantContext
{
    public Guid TenantId { get; set; }
}
