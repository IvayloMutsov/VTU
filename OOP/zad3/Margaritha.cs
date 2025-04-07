using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop
{
    internal class Margaritha : Pizza
    {
        private int Tomatoes { get; set; } = 1;
        public Margaritha(string name, string size, DateTime date) : base(name, size, date)
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
                    Price = 5; 
                    PizzaDough = 300;
                    break;
                case "medium":
                    Price = 10;
                    PizzaDough = 500;
                    break;
                case "big":
                    Price = 15;
                    PizzaDough = 800;
                    break;
            }
            Price *= quantity;
            int finalPizzaDough = quantity * PizzaDough;
            int finalTomatoes = quantity * Tomatoes;
            Console.WriteLine($"{Name} preparing...");
            Console.WriteLine($"Pizza dough {quantity}*{PizzaDough}={finalPizzaDough}gr");
            Console.WriteLine($"Tomatoes {quantity}*{Tomatoes}={finalTomatoes}");
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
