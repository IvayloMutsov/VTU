using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public class BankOffice : Invoker
    {
        private Invoker successor;

        public override void ExecuteCommand()
        {
            command.Execute();
        }

        public override void SetCommand(Command command)
        {
            if (command.GetType().Name.Equals("Deposit") || command.GetType().Name.Equals("Transaction"))
            {
                this.command = command;
            }
            else
            {
                successor.SetCommand(command);
                successor.ExecuteCommand();
            }
        }

        public void SetSuccessor(Invoker inv)
        {
            this.successor = inv;
        }
    }
}
