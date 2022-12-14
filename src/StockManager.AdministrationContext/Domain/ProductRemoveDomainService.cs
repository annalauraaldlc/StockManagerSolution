using ElemarJR.FunctionalCSharp;
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

            if (product.IsRemoved)
                return new Exception("Product is alredy removed.");

            var inventoryStatus = _productRepository.InventoryStatus(id);

            if (inventoryStatus > 0) 
                return new Exception("Product has itens in inventory.");

            product.SetAsRemoved();

            return product;
        }
    }
}
