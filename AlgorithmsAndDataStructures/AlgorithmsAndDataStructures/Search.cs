using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public class Search
    {
        public static bool LinearSerach(int[] data, int x)
        {
            bool found = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == x)
                {
                    found = true;
                    Console.WriteLine("Found the element x: " + x);
                    return found;
                }
            }
            return found;
        }

        public static bool BinarySearch(int[] data, int x)
        {
            bool found = false;
            int l = 0;
            int r = data.Length - 1;
            while (l != r)
            {
                int m = data[(l + r) / 2];
                if (m == x)
                {
                    found = true;
                    Console.WriteLine("Found element x = " + x);
                    return found;
                }
                else if (x < m)
                {
                    r = (l + r - 1) / 2;
                }
                else
                {
                    l = (l + r + 1) / 2;
                }
            }
            if (data[l] == x)
            {
                found = true;
                Console.WriteLine("Found element x = " + x);
                return found;
            }
            return found;
        }

        public static void Count(int[] data, int x)
        {
            int counter = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == x)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
