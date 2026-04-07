using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public class BankAtm : Invoker
    {
        [Range(0,20000)]
        public int availableMoney = 20000;

        public override void ExecuteCommand()
        {
            command.Execute();
        }

        public override void SetCommand(Command command)
        {
            if (command.GetType().Name.Equals("Withdraw") || command.GetType().Name.Equals("CheckBalance"))
            {
                this.command = command;
            }
            else
            {
                Console.WriteLine("Go to office");
            }
        }
    }
}
