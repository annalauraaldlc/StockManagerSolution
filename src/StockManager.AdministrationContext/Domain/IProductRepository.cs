using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.AdministrationContext.Domain
{
    public interface IProductRepository
    {
        Product GetByName(string name);
    }
}
