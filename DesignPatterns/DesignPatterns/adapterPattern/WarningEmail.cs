using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapterPattern
{
    public class WarningEmail : Adaptee
    {
        private string message;// WARNING!\nThis is a warning about...

        public WarningEmail(string msg)
        {
            message = msg;
        }

        public override void Execute()
        {
            Console.WriteLine(message);
        }
    }
}
