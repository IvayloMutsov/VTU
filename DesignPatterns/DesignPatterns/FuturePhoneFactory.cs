using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class FuturePhoneFactory : CreatorFactory
    {
        public override void Create()
        {
            Console.Write("Enter phone name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone screen size in inches: ");
            double screenSize = double.Parse(Console.ReadLine());

            Console.Write("Enter phone battery life: ");
            int batteryLife = int.Parse(Console.ReadLine());

            Console.Write("Enter phone storage size in GB: ");
            double storage = double.Parse(Console.ReadLine());

            Console.Write("Enter phone mobile data type: ");
            string mobileData = Console.ReadLine();

            Console.Write("Enter phone camera megapixels: ");
            int megapixels = int.Parse(Console.ReadLine());

            Technology t = new FuturePhone(name, screenSize, batteryLife, storage, mobileData, megapixels);
            devices.Add(t);
        }
    }
}
