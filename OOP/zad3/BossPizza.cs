using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop
{
    internal class BossPizza : Pizza
    {
        public int Ham { get; set; } = 100;
        public BossPizza(string name, string size, DateTime date) : base(name, size, date)
        {
            Name = name;
            Size = size;
            Date = date;
        }

        protected override void MakePizza(int quantity)
        {
            switch (Size)
            {
                case "small":
                    Price = 20;
                    PizzaDough = 300;
                    break;
                case "medium":
                    Price = 25;
                    PizzaDough = 500;
                    break;
                case "big":
                    Price = 30;
                    PizzaDough = 800;
                    break;
            }
            Price *= quantity;
            int finalPizzaDough = quantity * PizzaDough;
            int finalHam = quantity * Ham;
            Console.WriteLine($"{Name} preparing...");
            Console.WriteLine($"Pizza dough {quantity}*{PizzaDough}={finalPizzaDough}gr");
            Console.WriteLine($"Tomatoes {quantity}*{Ham}={finalHam}");
            Console.WriteLine($"Total: ${Price}");
        }

        public void GetPizza(int numOfPizzas)
        {
            MakePizza(numOfPizzas);
        }

        public override int GetTotalPrice(int num)
        {
            int total = Price * num;
            return total;
        }
    }
}
