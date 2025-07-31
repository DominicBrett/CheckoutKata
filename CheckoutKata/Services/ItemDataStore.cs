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
        private new Dictionary<string, ItemData> _items = new Dictionary<string, ItemData>
        {
            {"A", new ItemData(){Price = 50} },
            {"B", new ItemData(){Price=30  } },
            {"C", new ItemData(){Price=20 } },
            {"D", new ItemData(){Price=15} }
        };

        // What would we like to do if we don't have a item in our pricestore
        public int GetItemPrice(string sku)
        {
            return _items[sku].Price;
        }
    }
}
