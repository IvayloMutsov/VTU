using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Motorcycle : LandVeichle
    {
        public Motorcycle(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected override void GetInfo()
        {
            Description = $"{Name} - Max speed: 170 km/h, Fuel tank: 30 liters gas, Kilometers passed: 64 000";
            Console.WriteLine(Description);
            GetNumberOfWheels();
        }

        protected override void GetNumberOfWheels()
        {
            Console.WriteLine($"The numer of wheels of the {Name} is 2");
        }

        public void GiveDescription()
        {
            GetInfo();
        }
    }
}
