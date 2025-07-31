using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Entities
{
    public class Item
    {
        // this is here for easier testing but dosen't need to be
        public required string Sku { get; set; }
        public int Quantity { get; set;} = 1;
        public int Price { get; set; }
        public Promotion? Promotion { get; set; }
    }
}
