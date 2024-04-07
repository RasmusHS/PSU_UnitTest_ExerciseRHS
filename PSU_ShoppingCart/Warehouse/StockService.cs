using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU_ShoppingCart.Warehouse
{
    public class StockService : IStockService
    {
        private List<ProductStock> products;        
        public StockService() 
        {
            products = new List<ProductStock>();
        }
        public void AddToStock(Product product, int amount)
        {
            Ensure.That(product, nameof(product)).IsNotNull();
            Ensure.That(amount, nameof(amount)).IsGt<int>(0);
            //get the product
            var productStock = Get(product.SKU);
            productStock.Amount += amount;
        }

        public int GetAmountInStock(string sku)
        {
            var stockProduct = Get(sku);
            return stockProduct.Amount;
        }

        public void TakeFromStock(Product product, int amount)
        {
            var productStock = Get(product.SKU);
            if(productStock.Amount < amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            productStock.Amount -= amount;
        }

        private ProductStock Get(string sku)
        {
            return this.products.Where(x => x.Product.SKU == sku).FirstOrDefault();
        }

        private class ProductStock
        {
            public Product Product { get; set; }
            public int Amount { get; set; } 
        }
    }
}
