using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Phone : Technology
    {
        public int BatteryLife { get; }

        public double StorageSize { get; }

        public string MobileDataType { get; }

        public Phone(string name, double screenSize, int batteryLife, double storageSize
            , string mobileData) :base(name,screenSize)
        {
            BatteryLife = batteryLife;
            StorageSize = storageSize;
            MobileDataType = mobileData;
        }
    }
}
