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

        public static void LongNumSum(int n)
        {
            Queue<int> num1 = new Queue<int>();
            Queue<int> num2 = new Queue<int>();
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            Stack<int> result = new Stack<int>();
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(10);
                num1.Enqueue(x);
                stack1.Push(x);
            }
            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(10);
                num2.Enqueue(x);
                stack2.Push(x);
            }
            int div = 0;
            for (int i = 0; i < n; i++)
            {
                int x1 = stack1.Pop();
                int x2 = stack2.Pop();
                int sum = x1 + x2 + div;
                div = sum / 10;
                result.Push(sum % 10);
            }
            if (div == 1)
            {
                result.Push(div);
            }
            Console.WriteLine(string.Join("",num1));
            Console.WriteLine(string.Join("",num2));
            Console.WriteLine(string.Join("",result));
        }

        public static void LongNumSub(int n)
        {
            Queue<int> num1 = new Queue<int>();
            Queue<int> num2 = new Queue<int>();
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            Stack<int> result = new Stack<int>();
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(10);
                num1.Enqueue(x);
                stack1.Push(x);
            }
            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(10);
                num2.Enqueue(x);
                stack2.Push(x);
            }
            int div = 0;
            for (int i = 0; i < n; i++)
            {
                int x1 = stack1.Pop();
                int x2 = stack2.Pop();
                int sum = x1 - x2 - div;
                if (sum < 0)
                {
                    sum += 10;
                    div = 1;
                }
                else
                {
                    div = 0;
                }
                result.Push(sum);
            }
            Console.WriteLine(string.Join("", num1));
            Console.WriteLine(string.Join("", num2));
            if (div == 1)
            {
                Console.Write('-');
            }
            Console.WriteLine(string.Join("", result));
        }

        public static void TreeMatrix(int n)
        {
            Edge e1 = new Edge(1,2,6);
            Edge e2 = new Edge(1,3,5);
            Edge e3 = new Edge(2,4,3);
            Edge e4 = new Edge(2,8,5);
            Edge e5 = new Edge(3,4,2);
            Edge e6 = new Edge(3,5,4);
            Edge e7 = new Edge(4,6,1);
            Edge e8 = new Edge(5,6,7);
            Edge e9 = new Edge(5,7,1);
            Edge e10 = new Edge(6,7,9);
            Edge e11 = new Edge(6,8,4);
            Edge e12 = new Edge(7,8,2);
            List<Edge> list = new List<Edge>{e1,e2,e3,e4,e5,e6,e7,e8,e9,e10,e11,e12 };
            int[,] arr = new int[n, n];
            foreach (var e in list)
            {
                arr[e.top1 - 1, e.top2 - 1] = e.weight;
                arr[e.top2 - 1, e.top1 - 1] = e.weight;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void TreeMatrixFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            List<Edge> list = new List<Edge>();
            int n = 0;
            using (reader)
            {
                string line = reader.ReadLine();
                while(line != null)
                {
                    int[] nums = line.Split(',').Select(int.Parse).ToArray();
                    list.Add(new Edge(nums[0], nums[1], nums[2]));
                    n = nums[1];
                    line = reader.ReadLine();
                }
            }
            int[,] arr = new int[n, n];
            foreach (var e in list)
            {
                arr[e.top1 - 1, e.top2 - 1] = e.weight;
                arr[e.top2 - 1, e.top1 - 1] = e.weight;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    struct Edge
    {
        public int top1;
        public int top2;
        public int weight;
        public Edge(int top1, int top2, int weight)
        {
            this.top1 = top1;
            this.top2 = top2;
            this.weight = weight;
        }
    }
}
