using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Entities
{
    public class Item
    {
        public int Price { get; set; }
        // for now I will store the quantity of items the user has here but I would like to consider moving this if I have time
        public int Quantity { get; set; }
    }
}
