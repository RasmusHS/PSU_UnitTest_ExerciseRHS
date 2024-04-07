using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU_ShoppingCart.Warehouse
{
    public interface IStockService
    {
        int GetAmountInStock(string sku);
        void AddToStock(Product product, int amount);
        void TakeFromStock(Product product, int amount);
    }
}
