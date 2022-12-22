using Newtonsoft.Json;
using StockManager.Gateway.Infra;

namespace StockManager.Gateway.Middleware
{
    public class TenantResolverMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            ITenantRepository repository)
        {
            var tenantName = context.Request.Headers["Tenant"];

            var result = repository.GetByNameAsync(tenantName);

            if (result is null)
            {
                var error = JsonConvert.SerializeObject(new { error = "Tenant not found" });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(error);
            }
            else
            {
                context.Request.Headers["Tenant"] = JsonConvert.SerializeObject(result);
                await _next(context);
            }
        }
    }
}
