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
        public void ItemDataStore_GetItemPrice_ShouldReturnCorrectPrice(string sku, int expectedPrice)
        {
            var actualPrice = _itemDataStore.GetItemPrice(sku);
            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}