using ElemarJR.FunctionalCSharp;
using StockManager.AdministrationContext.Domain.ProductAggregate;
using System;

namespace StockManager.AdministrationContext.Domain
{
    public class ProductRemoveDomainService
    {
        private IProductRepository _productRepository;

        public ProductRemoveDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Try<Exception, Product> RemoveProduct(Guid id)
        {
            var product = _productRepository.GetById(id);

            if (product is null)
                return new Exception("Product not found");

            var inventoryStatus = _productRepository.InventoryStatus(id);

            if (inventoryStatus > 0) 
                return new Exception("Product has itens in inventory.");

            var result = _productRepository.Remove(product);

            if (result.IsFailure)
                return new Exception("An error occurred, product is not removed.");

            return product;
        }
    }
}
