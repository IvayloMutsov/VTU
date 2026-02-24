using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class Technology
    {
        public string Name { get; }

        public double ScreenSize { get; }

        protected Technology(string name, double screenSize)
        {
            Name = name;
            ScreenSize = screenSize;
        }
    }
}
