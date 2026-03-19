using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public class Bitwise
    {
        public static void GrayCode2(int k)
        {
            long p2 = (1L << k);
            for (int i = 0; i < p2; i++)
            {
                Console.WriteLine("{0}", CountPower2(i + 1));
            }
        }

        private static int CountPower2(long n)
        {
            int count = 0;
            while ((n & 1) == 0)
            {
                count++;
                n >>= 1;
            }
            return count;
        }

        private static int CountPower2Rec(long n)
        {
            if (n % 2 == 1)
            {
                return 0;
            }
            else
            {
                return 1 + CountPower2Rec(n / 2);
            }
        }

        public static void ToUpper(string s)
        {
            int mask = ~(1 << 5);
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] &= (char)mask;
            }
            Console.WriteLine(sb.ToString());
        }

        public static void ToLower(string s)
        {
            int mask = (1 << 5);
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] |= (char)mask;
            }
            Console.WriteLine(sb.ToString());
        }

        public static void ToChangeCase(string s)
        {
            int mask = (1 << 5);
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] ^= (char)mask;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
