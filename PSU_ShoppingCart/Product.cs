using EnsureThat;

namespace PSU_ShoppingCart
{
    public class Product
    {
        public Product(int price, string sku)
        {
            Ensure.That(price, nameof(price)).IsGte<int>(0);
            Ensure.That(sku, nameof(sku)).IsNotEmptyOrWhiteSpace();
            this.Price = price;
            this.SKU = sku;
        }
        public int Price { get; }
        public string SKU { get; }
        public string Name { get; set; }
    }
}
