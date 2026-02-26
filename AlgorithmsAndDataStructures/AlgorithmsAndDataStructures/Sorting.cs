using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmsAndDataStructures
{
    public class Sorting
    {
        public static void RandomData(int[] data, Random rand)
        {
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                data[i] = rand.Next(3*len);
            }
        }

        public static void PrintData(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
        }

        public static void SelectionSort(int[] data)
        {
            for (int j = 0; j < data.Length - 1; j++)
            {
                int min = data[j] , pos = j;
                for (int i = j + 1; i < data.Length; i++)
                {
                    if (data[i] < min)
                    {
                        min = data[i];
                        pos = i;
                    }
                }
                int temp = data[j];
                data[j] = min;
                data[pos] = temp;
            }

        }

        public static void BubbleSort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = data.Length - 1; j > i ; j--)
                {
                    if (data[j - 1] > data[j])
                    {
                        int temp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = temp;
                    }
                }
            }
        }

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
            while(l != r)
            {
                int m = data[(l + r) / 2];
                if (m == x)
                {
                    found = true;
                    Console.WriteLine("Found element x = " + x);
                    return found;
                }
                else if(x < m)
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
