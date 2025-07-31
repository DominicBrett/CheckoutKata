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
        private new Dictionary<string, Item> _items = new Dictionary<string, Item>
        {
            {"A", new Item(){Price = 50} },
            {"B", new Item(){Price=30  } },
            {"C", new Item(){Price=20 } },
            {"D", new Item(){Price=15} }
        };

        // What would we like to do if we don't have a item in our pricestore
        public int GetItemPrice(string sku)
        {
            return _items[sku].Price;
        }
    }
}
