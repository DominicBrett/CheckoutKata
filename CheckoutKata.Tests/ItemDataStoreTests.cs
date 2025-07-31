using CheckoutKata.Entities;
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

        [Fact]
        public void AddOrUpdateItem_ShouldAddANewItem_IfItDosentAlreadyExsistInTheDataStore()
        {
            // Arrange
            var expectedItem = new Item() { Price = 1, Sku = "D", Promotion = new Promotion() { Price = 1, QuantityRequirement = 1 } };

            // Act
            _itemDataStore.AddOrUpdateItem(expectedItem);

            // Assert
            var item = _itemDataStore.GetItemItem(expectedItem.Sku);
            Assert.Equal(expectedItem.Price, item.Price);
            Assert.Equal(expectedItem.Sku, item.Sku);
            Assert.Equal(expectedItem.Promotion, item.Promotion);
        }
        [Fact]
        public void AddOrUpdateItem_ShouldUpdateExsistingItem_IfItAlreadyExsistInTheDataStore()
        {
            // Arrange
            var expectedItem = new Item() { Price = 1, Sku = "A", Promotion = new Promotion() { Price = 1, QuantityRequirement = 1 } };

            // Act
            _itemDataStore.AddOrUpdateItem(expectedItem);

            // Assert
            var item = _itemDataStore.GetItemItem(expectedItem.Sku);
            Assert.Equal(expectedItem.Price, item.Price);
            Assert.Equal(expectedItem.Sku, item.Sku);
            Assert.Equal(expectedItem.Promotion, item.Promotion);
        }
    }
}