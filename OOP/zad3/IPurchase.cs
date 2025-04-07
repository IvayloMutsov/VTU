using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop
{
    internal interface IPurchase
    {
        public int Price { get; set; }
        public virtual int GetTotalPrice(int num) { int total = Price * num; return total; }
    }
}
