using CheckoutKata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests
{
    public class CheckoutTest
    {
        [Fact]
        public void Scan_ShouldAddCorrectItemToBasket()
        {
            // Arrange
            var checkout = new Checkout();

            // Act
            checkout.Scan("A");

            var item = checkout.GetItemFromBasket("A");

            // Assert
            Assert.NotNull(item);
            Assert.Equal("A", item.Name);
            Assert.Equal(50, item.Price);

        }
    }
}
