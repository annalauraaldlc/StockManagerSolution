using ElemarJR.FunctionalCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.AdministrationContext.Domain.ProductAggregate
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        Product GetByName(string name);
        Try<Exception, Product> Update(Product productUpdated);
        Try<Exception, Unit> Remove(Product productToRemove);
        int InventoryStatus(Guid id);
    }
}
