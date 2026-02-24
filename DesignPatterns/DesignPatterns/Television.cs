using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Television : Technology
    {
        public int Resolution { get; }

        public bool IsSmart { get; }

        public Television(string name, double screenSize, int resolution, bool isSmart)
            :base(name,screenSize)
        {
            Resolution = resolution;
            IsSmart = isSmart;
        }
    }
}
