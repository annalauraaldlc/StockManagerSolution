using Newtonsoft.Json;
using SaasKit.Multitenancy;
using StockManager.Infra.Multitenancy;

namespace StockManager.Web.Api.Multitenancy
{
    public class TenantResolver : ITenantResolver<Tenant>
    {
        public Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            var strTenant = context.Request.Headers["Tenant"];

            var tenant = JsonConvert.DeserializeObject<Tenant>(strTenant);

            if (tenant != null)
                return Task.FromResult(new TenantContext<Tenant>(tenant));

            throw new Exception($"Tenant was not found. Tenant: {strTenant}");
        }
    }

}
