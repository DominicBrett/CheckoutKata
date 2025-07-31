using CheckoutKata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Services
{
    public class ItemDataStore
    {
        private readonly new Dictionary<string, Item> _items = new Dictionary<string, Item>
        {
            {"A", new Item(){Sku = "A", Price = 50} },
            {"B", new Item(){Sku = "B",Price=30  } },
            {"C", new Item(){Sku = "C",Price=20 } },
            {"D", new Item(){Sku = "D",Price=15} }
        };

        // What would we like to do if we don't have a item in our pricestore
        public int GetItemPrice(string sku)
        {
            return _items[sku].Price;
        }
    }
}
