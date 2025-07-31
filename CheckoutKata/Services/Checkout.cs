
using CheckoutKata.Entities;
using CheckoutKata.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Services
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, Item> _basket = [];
        private readonly ItemDataStore _store = new ItemDataStore();
        public void Scan(string sku)
        {
            if(_basket.TryGetValue(sku, out var basket))
            {
                _basket[sku].Quantity++;
            } 
            else
            {
                try
                {
                    var item = _store.GetItemItem(sku);
                    _basket.Add(sku, item);
                }
                catch (KeyNotFoundException ex)
                {
                    throw new ItemNotFoundException($"{sku} is not found in the item store");
                }
 
            }
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach (var bItem in _basket)
            {
                var item = bItem.Value;
                if (item.Promotion == null || item.Quantity < item.Promotion.QuantityRequirement)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                else
                {
                    var dealQuantity = item.Quantity / item.Promotion.QuantityRequirement;
                    var remainderQuantity = item.Quantity % item.Promotion.QuantityRequirement;
                    totalPrice += dealQuantity * item.Promotion.Price;
                    totalPrice += remainderQuantity * item.Price;
                }
            }
            return totalPrice;
        }

        public Item GetItemFromBasket(string item)
        {
            return _basket[item];
        }
    }
}
