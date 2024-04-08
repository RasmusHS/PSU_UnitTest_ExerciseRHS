using EnsureThat; // Importing the EnsureThat library for input validation.

namespace PSU_ShoppingCart // Declaring a namespace for the class.
{
    public class Product // Defining a public class named Product.
    {
        // Constructor for Product class with parameters price and sku.
        public Product(int price, string sku)
        {
            // Using Ensure.That for input validation, ensuring that price is greater than or equal to 0.
            Ensure.That(price, nameof(price)).IsGte<int>(0);
            // Using Ensure.That for input validation, ensuring that sku is not null, empty, or whitespace.
            Ensure.That(sku, nameof(sku)).IsNotEmptyOrWhiteSpace();

            // Assigning the values passed to the constructor to Price and SKU properties.
            this.Price = price;
            this.SKU = sku;
        }

        // Readonly property for Price, allowing only retrieval of the value.
        public int Price { get; }

        // Readonly property for SKU, allowing only retrieval of the value.
        public string SKU { get; }

        // Property for Name, allowing both retrieval and assignment of the value.
        public string Name { get; set; }
    }
}
