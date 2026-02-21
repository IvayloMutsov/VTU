using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
