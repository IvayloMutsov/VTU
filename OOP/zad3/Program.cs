
namespace PizzaShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> days = new List<DateTime>();
            List<Pizza> orders = new List<Pizza>();
            Console.WriteLine("MENU - Margaritha and Boss`Pizza");
            Console.WriteLine("Piza name / quantity / size / date of purchase");
            string[] purchasePizza = new string[4];
            while (!purchasePizza.Contains("end"))
            {
                Console.Write("Pizza ");
                purchasePizza = Console.ReadLine().Split(' ');
                switch (purchasePizza[0])
                {
                    case "Margaritha": Margaritha m = new Margaritha(purchasePizza[0], purchasePizza[2], DateTime.Parse(purchasePizza[3]));
                        orders.Add(m);
                        days.Add(DateTime.Parse(purchasePizza[3]));
                        m.GetPizza(int.Parse(purchasePizza[1]));
                        break;
                    case "Boss`Pizza":
                        BossPizza b = new BossPizza(purchasePizza[0], purchasePizza[2], DateTime.Parse(purchasePizza[3]));
                        orders.Add(b);
                        days.Add(DateTime.Parse(purchasePizza[3]));
                        b.GetPizza(int.Parse(purchasePizza[1]));
                        break;
                }
            }
            Console.WriteLine("Cash register reset: ");
            DateTime[] dates = days.Distinct().ToArray();
            for(int i = 0; i < dates.Length; i++)
            {
                Console.WriteLine(dates[i]);
                Console.WriteLine($"Total pizzas {orders.Count}");
                Console.WriteLine($"Margarithas {orders.Select(x => x.GetType() is Margaritha).Count()}");
                Console.WriteLine($"Boss`Pizza {orders.Select(x => x.GetType() is BossPizza).Count()}");
                Console.WriteLine($"Total income = {orders[i].GetTotalPrice(orders.Count)}");
            }
        }
    }
}
