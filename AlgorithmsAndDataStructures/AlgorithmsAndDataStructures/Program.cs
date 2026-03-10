using System.Diagnostics;

namespace AlgorithmsAndDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //int[] arr = new int[5000000];
            //Sorting.RandomData(arr,new Random());
            ////Sorting.PrintData(arr);
            ////Console.WriteLine();
            //Stopwatch w = new Stopwatch();
            //w.Start();
            //Sorting.HeapSort(arr);
            //w.Stop();
            ////Console.WriteLine();
            ////Sorting.PrintData(arr);
            ////Console.WriteLine();
            //Console.WriteLine(w.ElapsedMilliseconds);
            int[] arr = {9,5,8,2,4,6,7,0,1,3};
            int count = 0;
            do
            {
                if (Sorting.IsHeap(arr))
                {
                    count++;
                }
            } while (Sorting.NextPermutation(arr));
            Console.WriteLine(count);
        }
    }
}
