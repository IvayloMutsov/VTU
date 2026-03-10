using DesignPatterns.adapterPattern;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Adapter adapter = new Adapter();
            PromotionEmail p = new PromotionEmail("<h1>Promotion</h1>\n<p>We are sending you this email about our promotion ...</p>");
            WarningEmail w = new WarningEmail("WARNING!\nThis is a warning about...");
            adapter.SendEmail(p);
            adapter.SendEmail(w);
        }
    }
}
