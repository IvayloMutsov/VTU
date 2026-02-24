using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class GamingPhone : FuturePhone
    {
        public int RamGb { get; set; }

        public GamingPhone(string name, double screenSize, int batteryLife, double storageSize,
            string mobileData, int megapixels, int ramgb) : base(name, screenSize, batteryLife, storageSize,
                mobileData, megapixels)
        {
            RamGb = ramgb;
        }
    }
}
