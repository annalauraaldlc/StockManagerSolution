using Microsoft.AspNetCore.Mvc;
using StockManager.Infra.Multitenancy;

namespace StockManager.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTenantController : ControllerBase
    {
        private readonly ILogger<TestTenantController> _logger;
        private readonly Tenant _tenant;

        public TestTenantController(ILogger<TestTenantController> logger, Tenant tenant)
        {
            _logger = logger;
            _tenant = tenant;
        }

        [HttpGet]
        public Tenant Get()
        {
            return _tenant;
        }
    }
}