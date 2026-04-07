using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public abstract class Command
    {
        protected Receiver receiver;

        protected int amount;

        public Command(Receiver receiver, int amount)
        {
            this.receiver = receiver;
            this.amount = amount;
        }

        protected Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public int GetAmount()
        {
            return amount;
        }

        public abstract void Execute();
    }
}
