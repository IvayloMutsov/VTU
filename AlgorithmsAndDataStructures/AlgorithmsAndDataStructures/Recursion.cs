using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public class Recursion
    {
        public static long[] Arr = new long[60];

        public static void FibNoRec(int n)
        {
            int a = 0, b = 1, c;
            Console.Write(a + " " + b);
            for (int i = 0; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.Write(" " + c);
            }
        }

        public static int FibRec(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
               return FibRec(n - 2) + FibRec(n - 1);
            }
        }

        public static long FibArr(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                if (Arr[n] == 0)
                {
                    Arr[n] = FibArr(n - 1) + FibArr(n - 2);
                }
                return Arr[n];
            }
        }

        public static void Hanoi(char A, char B, char C, int n)
        {
            if (n > 1)
            {
                Hanoi(A, C, B, n - 1);
            }
            Console.WriteLine($"{A} -> {C}");
            if (n > 1)
            {
                Hanoi(B,A,C,n - 1);
            }
        }

        public static void GrayCode(int k)
        {
            if (k > 1)
            {
                GrayCode(k - 1);
            }
            Console.WriteLine(k);
            if (k > 1)
            {
                GrayCode(k - 1);
            }
        }

        public static void GrayCodeNoRec(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int n = i;
                int prevBit = 0;
                int gray = 0;
                int power = 1;

                while (power < count) power *= 2;
                power /= 2;

                while (power > 0)
                {
                    int currentBit = n / power;
                    n %= power;

                    int grayBit = (currentBit + prevBit) % 2;
                    gray += grayBit * power;

                    prevBit = currentBit;
                    power /= 2;
                }

                Console.WriteLine(gray);
            }
        }
    }
}
