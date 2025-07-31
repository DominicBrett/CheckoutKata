namespace CheckoutKata.Tests
{
    public class ItemDataStoreTests
    {
        private const _itemDataStore = ItemDataStoreFactory.CreateDataStoreWithItems();


        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]dombrett777@outlook.com
        public void ItemDataStore_GetPrice_ShouldReturnCorrectPrice(string sku, int expectedPrice)
        {
            var actualPrice = _itemDataStore.GetPrice(sku);
            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}