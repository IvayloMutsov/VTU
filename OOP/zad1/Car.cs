using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Car : LandVeichle
    {
        public Car(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected override void GetInfo()
        {
            Description = $"{Name} - Max speed: 240 km/h, Fuel tank: 40 liters gas, Kilometers passed: 180 000";
            Console.WriteLine(Description);
            GetNumberOfWheels();
        }

        protected override void GetNumberOfWheels()
        {
            Console.WriteLine($"The numer of wheels of the {Name} is 4");
        }

        public void GiveDescription()
        {
            GetInfo();
        }
    }
}
