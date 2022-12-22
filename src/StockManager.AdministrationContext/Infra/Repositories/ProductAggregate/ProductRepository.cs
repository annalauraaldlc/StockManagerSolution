using AutoMapper;
using ElemarJR.FunctionalCSharp;
using StockManager.AdministrationContext.Domain.ProductAggregate;
using StockManager.AdministrationContext.Infra.Data;
using System;
using System.Linq;

namespace StockManager.AdministrationContext.Infra.Repositories.ProductAggregate
{
    public class ProductRepository : IProductRepository
    {
        private AdministrationDbContext _dbContext;
        private IMapper _mapper;

        public ProductRepository(AdministrationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Product GetById(Guid id)
        {
            var productTable = _dbContext.Products.FirstOrDefault(p => p.Id == id && !p.IsRemoved);

            return _mapper.Map<Product>(productTable);
        }

        public Product GetByName(string name)
        {
            var productTable = _dbContext.Products.FirstOrDefault(p => p.Name == name && !p.IsRemoved);

            return _mapper.Map<Product>(productTable);
        }

        public int InventoryStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public Try<Exception, Unit> Remove(Product productToRemove)
        {
            var productTable = _dbContext.Products.FirstOrDefault(p => p.Id == productToRemove.Id && !p.IsRemoved);

            if (productTable == null)
                return new Exception("Produto não encontrado");

            productTable.IsRemoved = true;

            _dbContext.SaveChanges();

            return new Unit();
        }

        public Try<Exception, Product> Update(Product productUpdated)
        {
            var productTable = _dbContext.Products.FirstOrDefault(p => p.Id == productUpdated.Id && !p.IsRemoved);

            if (productTable == null)
                return new Exception("Produto não encontrado");

            productTable.Name = productUpdated.Name;
            productTable.Description = productUpdated.Description;

            _dbContext.SaveChanges();

            return _mapper.Map<Product>(productTable);
        }
    }
}
