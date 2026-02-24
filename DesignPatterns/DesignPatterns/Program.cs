namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            CreatorFactory[] creators = new CreatorFactory[4];
            creators[0] = new PhoneFactory();
            creators[1] = new TvFactory();
            creators[2] = new FuturePhoneFactory();
            creators[3] = new GamingPhoneFactory();

            foreach (var item in creators)
            {
                foreach (var device in item.devices)
                {
                    Console.WriteLine($"Created {device.Name} {device.GetType().Name}");
                }
            }
        }
    }
}
