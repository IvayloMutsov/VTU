using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class CreatorFactory
    {
        public List<Technology> devices = new List<Technology>();

        protected CreatorFactory()
        {
            this.Create();
        }

        public abstract void Create();
    }
}
