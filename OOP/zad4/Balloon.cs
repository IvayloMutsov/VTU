using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balloonPop
{
    public class Balloon
    {
        public string Color { get; private set; }
        public int Size { get; private set; }

        public Balloon(string color)
        {
            Color = color;
            Size = new Random().Next(1, 11); // Size
        }
    }
}
