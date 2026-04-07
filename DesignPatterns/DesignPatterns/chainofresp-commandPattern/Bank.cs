using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public class Bank
    {
        private List<Invoker> officesAndAtms;

        public Bank()
        {
            officesAndAtms = new List<Invoker>();
        }

        public void Add(Invoker inv)
        {
            officesAndAtms.Add(inv);
        }

        public List<Invoker> GetList()
        {
            return officesAndAtms;
        }
    }
}
