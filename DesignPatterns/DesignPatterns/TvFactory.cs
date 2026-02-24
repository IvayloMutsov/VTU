using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class TvFactory : CreatorFactory
    {
        public override void Create()
        {
            Console.Write("Enter TV name: ");
            string name = Console.ReadLine();
            Console.Write("Enter TV screen size in inches: ");
            double screenSize = double.Parse(Console.ReadLine());
            Console.Write("Enter TV resolution: ");
            int resolution = int.Parse(Console.ReadLine());
            Console.Write("Is TV smart: ");
            bool isSmart = bool.Parse(Console.ReadLine());
            Technology t = new Television(name,screenSize,resolution,isSmart);
            devices.Add(t);
        }
    }
}
