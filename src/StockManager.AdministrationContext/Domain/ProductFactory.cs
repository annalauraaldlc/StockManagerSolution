using ElemarJR.FunctionalCSharp;
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

        public Try<Exception, Product> Create(string name, string description)
        {
            var product = _repository.GetByName(name);

            if (product != null)
                return new Exception("Product should be unique");

            return Try.Run(() => new Product(name, description));
        }
    }
}
