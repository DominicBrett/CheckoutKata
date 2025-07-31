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
            Assert.Equal("A", item.Sku);
            Assert.Equal(50, item.Price);
            Assert.Equal(1, item.Quantity);

        }
        [Fact]
        public void Scan_ShouldTrackQuanitityOverMultipleCalls()
        {
            // Arrange
            var expectedQuantity = 33;
            var checkout = new Checkout();

            // Act
            for (int i = 0; i < expectedQuantity; i++)
            {
                checkout.Scan("A");
            }
            var item = checkout.GetItemFromBasket("A");

            // Assert
            Assert.NotNull(item);
            Assert.Equal("A", item.Sku);
            Assert.Equal(50, item.Price);
            Assert.Equal(expectedQuantity, item.Quantity);

        }
        [Fact]
        public void Scan_ShouldHandleMultipleUniqueItems()
        {
            // Arrange
            var checkout = new Checkout();

            // Act
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");

            var item1 = checkout.GetItemFromBasket("A");
            var item2 = checkout.GetItemFromBasket("B");

            // Assert
            Assert.NotNull(item1);
            Assert.Equal("A", item1.Sku);
            Assert.Equal(50, item1.Price);
            Assert.Equal(1, item1.Quantity);

            Assert.NotNull(item2);
            Assert.Equal("B", item2.Sku);
            Assert.Equal(30, item2.Price);
            Assert.Equal(2, item2.Quantity);

        }

        [Fact]
        public void GetTotalPrice_ShouldReturnCorrectPrice()
        {
            // Arrange
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            // Act
            var totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.Equal(115, totalPrice);
        }

        [Fact]
        public void GetTotalPrice_ShouldReturnCorrectPrice_IfPromotionsArePresent()
        {
            // Arrange
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            // Act
            var totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.Equal(210, totalPrice);
        }
    }
}
