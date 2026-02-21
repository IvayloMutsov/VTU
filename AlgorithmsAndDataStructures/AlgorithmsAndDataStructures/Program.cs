using System.Diagnostics;

namespace AlgorithmsAndDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 30000;
            int[] input = new int[n];
            int[] input2 = new int[n];
            Random rand = new Random();
            Sorting.RandomData(input, rand);
            Stopwatch w1 = new Stopwatch();
            Stopwatch w2 = new Stopwatch();
            w1.Start();
            Sorting.BubbleSort(input);
            w1.Stop();
            w2.Start();
            Sorting.SelectionSort(input2);
            w2.Stop();
            Console.WriteLine($"Bubble - {w1.ElapsedMilliseconds} / Selection - {w2.ElapsedMilliseconds}");
        }
    }
}
