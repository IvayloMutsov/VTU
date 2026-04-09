using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public class DataScructures
    {
        public static LinkedList<int> AlwaysSortedLinkedList(int numElements)
        {
            LinkedList<int> list = new LinkedList<int>();
            Random r = new Random();
            for (int i = 0; i < numElements; i++)
            {
                var item = list.First;
                int num = r.Next(0, 10);
                while (item != null && item.Value < num)
                {
                    item = item.Next;
                }
                if (item == null)
                {
                    list.AddLast(num);
                }
                else
                {
                    list.AddBefore(item, num);
                }
            }
            return list;
        }

        public static void AllPrimeNums()//three digits
        {
            List<int> list = new List<int>();
            for (int i = 101; i < 1000; i+=2)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", list));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                list.RemoveAll(x => x.ToString().Contains(n.ToString()));
            }
            Console.WriteLine(string.Join(" ", list));
        }

        private static bool IsPrime(int n)
        {
            if (n % 2 == 0)
            {
                return false;
            }
            for (int i = 2; i*i <= n; i+=2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void BiggestPrimeDelete()
        {
            LinkedList<int> list = new LinkedList<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int num = r.Next(1, 1000);
                list.AddLast(num);
            }
            Console.WriteLine(string.Join(" ", list));
            int max = 2;
            foreach (var item in list)
            {
                if (IsPrime(item) && item > max)
                {
                    max = item;
                }
            }
            Console.WriteLine(max);
            char[] temp = max.ToString().ToCharArray();
            int sum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                sum += int.Parse(temp[i].ToString());
            }
            Console.WriteLine(sum);
            foreach (var item in list.ToArray())
            {
                if (sum != 0 && item % sum == 0)
                {
                    list.Remove(item);
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }

        public static void TrainQueue()
        {
            Queue<int> q = new Queue<int>();
            Stack<int> s = new Stack<int>();
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    q.Enqueue(arr[i]);
                }
                else
                {
                    s.Push(arr[i]);
                }
            }
            int n = s.Count;
            for (int i = 0; i < n; i++)
            {
                q.Enqueue(s.Pop());
            }
            Console.WriteLine(string.Join(" ", q));
        }

        public static void NumToBinary()
        {
            Stack<int> stack = new Stack<int>();
            Console.Write("Enter Number to convert: ");
            int n = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                int leftover = n % 2;
                stack.Push(leftover);
                n /= 2;
            }
            Console.WriteLine(string.Join("",stack));
        }
    }
}
