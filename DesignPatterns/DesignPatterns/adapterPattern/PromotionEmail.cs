using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapterPattern
{
    public class PromotionEmail : Adaptee
    {
        private string message;//"<h1>Promotion</h1>\n<p>We are sending you this email about our promotion ...</p>"

        public PromotionEmail(string msg)
        {
            message = msg;
        }

        public override void Execute()
        {
            Console.WriteLine(message);
        }
    }
}
