
using CheckoutKata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Services
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, BasketItem> _basket = [];
        private readonly ItemDataStore _store = new ItemDataStore();
        public void Scan(string item)
        {
            if(_basket.TryGetValue(item, out var basket))
            {
                _basket[item].Quantity++;
            } 
            else
            {
                // What should we do if the item is not valid
                var price = _store.GetItemPrice(item);
                _basket.Add(item, new BasketItem() { Sku = item, Price = price, Quantity = 1 });
            }
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach (var bItem in _basket)
            {
                var item = bItem.Value;
                totalPrice += item.Price * item.Quantity;
            }
            return totalPrice;
        }

        public BasketItem GetItemFromBasket(string item)
        {
            return _basket[item];
        }
    }
}
