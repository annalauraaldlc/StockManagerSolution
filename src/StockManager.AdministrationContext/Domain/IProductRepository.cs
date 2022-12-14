using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.AdministrationContext.Domain
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        Product GetByName(string name);
        int InventoryStatus(Guid id);
    }
}
