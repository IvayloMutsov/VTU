using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapterPattern
{
    public interface ITarget
    {
        public abstract void SendEmail(Adaptee adaptee);
    }
}
