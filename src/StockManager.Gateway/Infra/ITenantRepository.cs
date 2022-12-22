using Microsoft.Extensions.Primitives;

namespace StockManager.Gateway.Infra
{
    public interface ITenantRepository
    {
        object? GetByNameAsync(string tenantName);
    }

    public class TenantRepository : ITenantRepository
    {
        public object? GetByNameAsync(string tenantName)
        {
            switch (tenantName)
            {
                case "ndd":
                    return new { Name = "ndd", ConnStr = "abc321" };
                case "ndd-2":
                    return new { Name = "ndd-2", ConnStr = "dfg456" };
                default:
                    return null;
            }
        }
    }
}
