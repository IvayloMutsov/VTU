using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public abstract class Invoker
    {
        protected Command command;

        public abstract void SetCommand(Command command);
        public abstract void ExecuteCommand();
    }
}
