using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.AdministrationContext.Domain
{
    public class ProductFactory
    {
        private IProductRepository _repository;

        public ProductFactory(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(string name, string description)
        {
            var product = _repository.GetByName(name);

            if (product != null)
                throw new Exception("Product should be unique");

            return new Product(name, description);
        }
    }
}
