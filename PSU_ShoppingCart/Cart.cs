using EnsureThat;
using PSU_ShoppingCart.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU_ShoppingCart
{
    public class Cart
    {
        private readonly IStockService stockService;
        public Cart(IStockService stockService) 
        {
            Products = new List<Product>();
        }
        public int Discount { get; private set; }

        private List<Product> Products { get; }

        public List<Product> GetProducts()
        {
            return this.Products;
        }

        public void ApplyDiscount(int discountAmount)
        {
            Ensure.That(discountAmount, nameof(discountAmount)).IsGt<int>(0);
            Ensure.That(discountAmount, nameof(discountAmount)).IsLte<int>(15);
            this.Discount = discountAmount;
        }
        public void AddProduct(Product product, int amount)
        {
            //do not allow the same product to be added twice
            if(!this.Products.Where(x=>x.SKU == product.SKU).Any())
            {
                int amountInStock = this.stockService.GetAmountInStock(product.SKU);
                if(amountInStock > 0 && amountInStock <= amount) 
                {
                    this.Products.Add(product);
                }                
            }
        }

        public int Total
        {
            get
            {
                int total = this.Products.Sum(x => x.Price);
                return total - Discount;
            }
        }
    }
}
