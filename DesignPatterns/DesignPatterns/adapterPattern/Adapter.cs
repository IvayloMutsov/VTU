using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapterPattern
{
    public class Adapter : ITarget
    {
        public void SendEmail(Adaptee adaptee)
        {
            adaptee.Execute();
        }
    }
}
