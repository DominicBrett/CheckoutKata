using CheckoutKata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Services
{
    public interface ICheckout
    {
        BasketItem GetItemFromBasket(string item);
        void Scan(string item);
        int GetTotalPrice();
    }
}
