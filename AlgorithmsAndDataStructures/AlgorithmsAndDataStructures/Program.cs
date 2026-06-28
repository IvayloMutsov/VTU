using System.Diagnostics;

namespace AlgorithmsAndDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int[] arr = new int[30];
            Sorting.RandomData(arr,new Random());
            Sorting.PrintData(arr);
            Console.WriteLine();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    stack.Push(arr[i]);
                }
                else
                {
                    queue.Enqueue(arr[i]);
                }
            }
            int average = 0;
            int numOfelementsInStack = stack.Count;
            while(stack.Count > 0)
            {
                average += stack.Pop();
            }
            average /= numOfelementsInStack;
            Console.WriteLine($"The everage of the stack is {average}");
            int[] bst = new int[queue.Count];
            int index = 0;
            bst[index] = queue.Dequeue();
            while (queue.Count > 0)
            {
                int temp = queue.Dequeue();
                if (temp > average)
                {
                    Console.WriteLine($"Tree element larger than the average: {temp}");
                }
                //if (temp < bst[index])
                //{
                //    bst[index * 2 + 1] = temp;
                //}
                //else
                //{
                //    bst[index * 2 + 2] = temp;
                //}
            }
        }
    }
}
