using Microsoft.AspNetCore.Mvc;
using SaasKit.Multitenancy;
using StockManager.AdministrationContext.Domain.ProductAggregate;
using StockManager.Infra.Multitenancy;

namespace StockManager.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _productRepository.GetById(id);

        }
    }
}