using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Helicopter : AirVeichle
    {
        public Helicopter(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected override void GetInfo()
        {
            Description = Description = $"{Name} - Lenght: 5 meters, Fuel tank: 400 liters, Cargo size: 7 tons";
            Console.WriteLine(Description);
            GetMaxFlightHeight();
        }

        protected override void GetMaxFlightHeight()
        {
            Console.WriteLine("The max height the helicopter can reach is 4 kilometers");
        }

        public void GiveDescription()
        {
            GetInfo();
        }
    }
}
