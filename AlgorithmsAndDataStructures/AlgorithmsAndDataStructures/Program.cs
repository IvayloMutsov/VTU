using System.Diagnostics;

namespace AlgorithmsAndDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int[] arr = new int[10];
            Sorting.RandomData(arr,new Random());
            Sorting.PrintData(arr);
            Console.WriteLine();
            Sorting.SelectionSort(arr);
            Sorting.PrintData(arr);
            Console.WriteLine();
            bool foundElement = Sorting.BinarySearch(arr,5);
            if (foundElement == false)
            {
                Console.WriteLine("Element not found!");
            }
            Console.Write("Which element to count? ");
            int n = int.Parse(Console.ReadLine());
            Sorting.Count(arr,n);
        }
    }
}
