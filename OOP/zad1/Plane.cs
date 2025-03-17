using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Plane : AirVeichle
    {
        public Plane(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected override void GetInfo()
        {
            Description = Description = $"{Name} - Lenght: 30 meters, Fuel tank: 400 liters, Cargo size: 12 tons";
            Console.WriteLine(Description);
            GetMaxFlightHeight();
        }

        protected override void GetMaxFlightHeight()
        {
            Console.WriteLine("The max height the plane can reach is 10 kilometers");
        }

        public void GiveDescription()
        {
            GetInfo();
        }
    }
}
