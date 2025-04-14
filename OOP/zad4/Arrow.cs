using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balloonPop
{
    public class Arrow
    {
        public string Color { get; private set; }
        public int Accuracy { get; private set; }

        public Arrow(string color)
        {
            Color = color;
            Accuracy = new Random().Next(1, 11); 
        }

        public bool CanPopBalloon(Balloon balloon)
        {
            return Color == balloon.Color && Accuracy >= balloon.Size;
        }
    }
}
