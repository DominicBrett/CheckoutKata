using CheckoutKata.Services;

namespace CheckoutKata.Tests
{
    public class ItemDataStoreTests
    {
        private readonly ItemDataStore _itemDataStore = new ItemDataStore();


        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void GetItem_ShouldReturnCorrectPrice(string sku, int expectedPrice)
        {
            var actualPrice = _itemDataStore.GetItemItem(sku);
            Assert.Equal(expectedPrice, actualPrice.Price);
        }

        [Fact]
        public void AddOrUpdateItemPrice_ShouldAddANewItem_IfItDosentAlreadyExsistInTheDataStore()
        {
            // Arrange
            var expectedItemSku = "E";
            var expectedItemPrice = 500;
            
            // Act
            _itemDataStore.AddOrUpdateItemPrice(expectedItemSku, expectedItemPrice);

            // Assert
            var item = _itemDataStore.GetItemItem(expectedItemSku);
            Assert.Equal(expectedItemPrice, item.Price);
            Assert.Equal(expectedItemSku, item.Sku);
        }

        [Fact]
        public void AddOrUpdateItemPrice_ShouldUpdateExsistingItem_IfItAlreadyExsistInTheDataStore()
        {
            // Arrange
            var expectedItemSku = "A";
            var expectedItemPrice = 999;

            // Act
            _itemDataStore.AddOrUpdateItemPrice(expectedItemSku, expectedItemPrice);

            // Assert
            var item = _itemDataStore.GetItemItem(expectedItemSku);
            Assert.Equal(expectedItemPrice, item.Price);
            Assert.Equal(expectedItemSku, item.Sku);
        }
    }
}