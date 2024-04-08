namespace PSU_ShoppingCart.Test
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_WithValidPriceAndSKU_ShouldCreateProduct()
        {
            // Arrange
            int price = 10;
            string sku = "ABC123";

            // Act
            var product = new Product(price, sku);

            // Assert
            Assert.Equal(price, product.Price);
            Assert.Equal(sku, product.SKU);
        }

        [Theory]
        [InlineData(0, "ABC123")] // Minimum price boundary case
        [InlineData(-1, "ABC123")] // Negative price boundary case
        public void Constructor_WithInvalidPrice_ShouldThrowArgumentException(int price, string sku)
        {
            // Arrange & Act & Assert
            Assert.Throws<System.ArgumentException>(() => new Product(price, sku));
        }

        [Theory]
        [InlineData(10, "")] // Empty SKU
        [InlineData(10, " ")] // Whitespace SKU
        [InlineData(10, null)] // Null SKU
        public void Constructor_WithInvalidSKU_ShouldThrowArgumentException(int price, string sku)
        {
            // Arrange & Act & Assert
            Assert.Throws<System.ArgumentException>(() => new Product(price, sku));
        }

        [Fact]
        public void Name_Property_CanBeSetAndGet()
        {
            // Arrange
            var product = new Product(10, "ABC123");
            string name = "Test Product";

            // Act
            product.Name = name;

            // Assert
            Assert.Equal(name, product.Name);
        }
    }
}