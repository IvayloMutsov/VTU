using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Boat : WaterVeichle
    {
        public Boat(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected override void GetInfo()
        {
            Description = $"{Name} - Lenght: 212 meters, Fuel tank: 2000 liters, Cargo size: 30 tons";
            Console.WriteLine(Description);
            GetMaxDiveDepth();
        }

        protected override void GetMaxDiveDepth()
        {
            Console.WriteLine("Max dive depth is 10 meters for the botom of the ship");
        }

        public void GiveDescription()
        {
            GetInfo();
        }
    }
}
