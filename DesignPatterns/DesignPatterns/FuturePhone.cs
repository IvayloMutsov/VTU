using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class FuturePhone : Phone
    {
        public int Megapixels { get; set; }

        public FuturePhone(string name, double screenSize, int batteryLife, double storageSize,
            string mobileData, int megapixels) 
            : base(name, screenSize, batteryLife, storageSize, mobileData)
        {
            Megapixels = megapixels;
        }
    }
}
