namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Car car = new Car(1, "Toyota Yaris");
            Motorcycle bike = new Motorcycle(2, "Motor Balkan");
            Plane plane = new Plane(3, "Boing 777");
            Helicopter chopper = new Helicopter(4, "Sikorsky Helicopter");
            Boat boat = new Boat(5, "Titanic");
            Submarine sub = new Submarine(6, "Triast submarine");
            car.GiveDescription();
            Console.WriteLine("=======================================");
            bike.GiveDescription();
            Console.WriteLine("=======================================");
            plane.GiveDescription();
            Console.WriteLine("=======================================");
            chopper.GiveDescription();
            Console.WriteLine("=======================================");
            boat.GiveDescription();
            Console.WriteLine("=======================================");
            sub.GiveDescription();
        }
    }
}
