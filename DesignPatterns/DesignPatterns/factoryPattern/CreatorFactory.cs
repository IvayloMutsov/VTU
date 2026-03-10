using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.factoryPattern
{
    public abstract class CreatorFactory
    {
        public List<Technology> devices = new List<Technology>();

        protected CreatorFactory()
        {
            Create();
        }

        public abstract void Create();
    }
}
