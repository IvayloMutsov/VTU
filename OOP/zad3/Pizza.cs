using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop
{
    abstract class Pizza : IPurchase
    {
        protected string Name { get; set; }
        protected int Price { get; set; }
        protected string Size { get; set; }
        protected int PizzaDough { get; set; }
        public DateTime Date { get; set; }
        int IPurchase.Price { get => Price; set => Price = value; }

        protected Pizza(string name, string size, DateTime date)
        {
            Name = name;
            Size = size;
            Date = date;
        }

        protected abstract void MakePizza(int quantity);

        public virtual int GetTotalPrice(int num) { int t = Price * num; return t;}
    }
}
