using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public class Transaction : Command
    {
        public Transaction(Receiver receiver, int amount) : base(receiver, amount)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }
}
