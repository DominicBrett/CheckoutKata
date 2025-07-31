using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Entities
{
    public class Promotion
    {
        public required int QuantityRequirement { get; set; }
        public required int Price { get; set; }
    }
}
