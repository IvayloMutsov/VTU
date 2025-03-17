using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    abstract internal class Veichle
    {
        protected int ID { get; set; }
        protected string Name { get; set; }
        protected string Description { get; set; }

        protected Veichle(int id, string name)
        {
            ID = id;
            Name = name;
        }

        protected abstract void GetInfo();
    }
}
