namespace VTU_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //zad 1
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Enter the lenght of the train (meters): ");
            double trainLenght = double.Parse(Console.ReadLine());
            Console.Write("Enter the speed of the train (m/sec): ");
            double trainSpeed = double.Parse(Console.ReadLine());
            Console.Write("Entr the time it takes the tran to pass through the bridge or tunel (sec):");
            double seconds = double.Parse(Console.ReadLine());
            double totalDistance = trainSpeed * seconds;
            double bridgeOrTunelDistance = totalDistance - trainLenght;
            Console.WriteLine($"The length of the bridge is {bridgeOrTunelDistance} meters");
        }
    }
}