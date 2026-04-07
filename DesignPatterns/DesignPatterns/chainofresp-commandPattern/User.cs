using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.chainofresp_commandPattern
{
    public class User : Receiver
    {
        protected Bank bank;

        protected int balance;

        protected string wantedAction;

        public User(Bank bank, int balance)
        {
            this.bank = bank;
            this.balance = balance;
        }

        public void Activate()
        {
            Command c;
            if (wantedAction != null)
            {
                if (wantedAction.Equals("Deposit"))
                {
                    Console.Write("How much to deposit");
                    int num = int.Parse(Console.ReadLine());
                    c = new Deposit(this,num);
                    
                }
                else if (wantedAction.Equals("Transaction"))
                {
                    Console.Write("How much to send/recieve");
                    int num = int.Parse(Console.ReadLine());
                    c = new Transaction(this, num);
                    
                }
                else if (wantedAction.Equals("Withdraw"))
                {
                    Console.Write("How much to withdraw");
                    int num = int.Parse(Console.ReadLine());
                    c = new Withdraw(this, num);
                    
                }
                else if (wantedAction.Equals("CheckBalance"))
                {
                    Console.WriteLine("Your balance is: " + balance);
                }
            }
        }

        public void SetAction(string action)
        {
            if (action.Equals("Deposit") || action.Equals("Transaction") || action.Equals("Withdraw") || action.Equals("CheckBalance"))
            {
                this.wantedAction = action;
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }
        }
    }
}
