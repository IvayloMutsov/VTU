using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    abstract internal class LandVeichle : Veichle
    {
        protected LandVeichle(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        protected abstract override void GetInfo();

        protected abstract void GetNumberOfWheels();
    }
}
