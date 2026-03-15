using DesignPatterns.adapterPattern;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            ITarget adapter = new Adapter();
            Adaptee p = new PromotionEmail("<h1>Promotion</h1>\n<p>We are sending you this email about our promotion ...</p>");
            Adaptee w = new WarningEmail("WARNING!\nThis is a warning about...");
            adapter.SendEmail(p);
            Console.WriteLine("-------------------------------");
            adapter.SendEmail(w);
        }
    }
}
