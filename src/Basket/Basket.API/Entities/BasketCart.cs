using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();
        public BasketCart() { }

        public BasketCart(string userName) => userName = UserName;

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    }
}
