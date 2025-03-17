using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP
{
    internal class Submarine : WaterVeichle
    {
        public Submarine(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected override void GetInfo()
        {
            Description = $"{Name} - Lenght: 70 meters, Fuel tank: 300 liters, Cargo size: 5 tons";
            Console.WriteLine(Description);
            GetMaxDiveDepth();
        }

        protected override void GetMaxDiveDepth()
        {
            Console.WriteLine("Max dive depth is 500 meters under the surface of the ocean");
        }

        public void GiveDescription()
        {
            GetInfo();
        }
    }
}
