using CheckoutKata.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Services
{
    public class ItemDataStore
    {
        private readonly new Dictionary<string, Item> _items = new Dictionary<string, Item>
        {
            {"A", new Item(){Sku = "A", Price = 50, Promotion = new Promotion() {QuantityRequirement = 3, Price = 130} } },
            {"B", new Item(){Sku = "B",Price=30, Promotion = new Promotion() {QuantityRequirement = 2, Price = 45}  } },
            {"C", new Item(){Sku = "C",Price=20 } },
            {"D", new Item(){Sku = "D",Price=15} }
        };

        public void AddOrUpdateItem(Item item)
        {
            var sku = item.Sku;
            if (_items.ContainsKey(sku))
            {
                _items[sku] = item;
            }
            else
            {
                _items.Add(sku, item);
            }
        }

        public void AddOrUpdateItemPrice(string sku, int price)
        {
            if (_items.ContainsKey(sku))
            {
                _items[sku].Price = price;
            }
            else
            {
                _items.Add(sku, new Item() { Sku = sku, Price = price });
            }
        }

        // What would we like to do if we don't have a item in our pricestore
        public Item GetItemItem(string sku)
        {
            return _items[sku];
        }
    }
}
