using Microsoft.Extensions.Primitives;

namespace StockManager.Gateway.Infra
{
    public interface ITenantRepository
    {
        object? GetByNameAsync(string tenantName);
    }
}
