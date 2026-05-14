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
            for (int i = 101; i < 1000; i += 2)
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
            for (int i = 2; i * i <= n; i += 2)
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
            Console.WriteLine(string.Join("", stack));
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
            Console.WriteLine(string.Join("", num1));
            Console.WriteLine(string.Join("", num2));
            Console.WriteLine(string.Join("", result));
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
            Edge e1 = new Edge(1, 2, 6);
            Edge e2 = new Edge(1, 3, 5);
            Edge e3 = new Edge(2, 4, 3);
            Edge e4 = new Edge(2, 8, 5);
            Edge e5 = new Edge(3, 4, 2);
            Edge e6 = new Edge(3, 5, 4);
            Edge e7 = new Edge(4, 6, 1);
            Edge e8 = new Edge(5, 6, 7);
            Edge e9 = new Edge(5, 7, 1);
            Edge e10 = new Edge(6, 7, 9);
            Edge e11 = new Edge(6, 8, 4);
            Edge e12 = new Edge(7, 8, 2);
            List<Edge> list = new List<Edge> { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12 };
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

        public static int[,] TreeMatrixFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            List<Edge> list = new List<Edge>();
            int n = 0;
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
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
            return arr;
        }

        public static void BFS()
        {
            int[,] arr = TreeMatrixFromFile("TextFile1.txt");
            int numV = arr.GetLength(0);
            int[] visited = new int[numV];
            for (int i = 0; i < numV; i++)
            {
                visited[i] = 0;
            }
            Console.Write("Input an inital vertex: ");
            int v = int.Parse(Console.ReadLine());
            visited[v - 1] = 1;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                Console.Write(current + " ");
                for (int i = 0; i < numV; i++)
                {
                    if (arr[current - 1, i] > 0 && visited[i] == 0)
                    {
                        queue.Enqueue(i + 1);
                        visited[i] = 1;
                    }
                }
            }
        }

        public static void DFS()
        {
            int[,] arr = TreeMatrixFromFile("TextFile1.txt");
            int numV = arr.GetLength(0);
            int[] visited = new int[numV];

            for (int i = 0; i < numV; i++)
            {
                visited[i] = 0;
            }

            Console.Write("Input an initial vertex: ");
            int v = int.Parse(Console.ReadLine());

            DFSRec(arr, v, visited, numV);
        }
        private static void DFSRec(int[,] arr, int v, int[] visited, int numV)
        {
            visited[v - 1] = 1;
            Console.Write(v + " ");

            for (int i = 0; i < numV; i++)
            {
                if (arr[v - 1, i] > 0 && visited[i] == 0)
                {
                    DFSRec(arr, i + 1, visited, numV);
                }
            }
        }

        public static void IncidenceMatrix()
        {
            int[,] adjMatrix = TreeMatrixFromFile("TextFile1.txt");
            int n = adjMatrix.GetLength(0);
            int edgeCount = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (adjMatrix[i, j] != 0)
                    {
                        edgeCount++;
                    }
                }
            }
            int[,] incidenceMatrix = new int[n, edgeCount];
            int edgeIndex = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (adjMatrix[i, j] != 0)
                    {
                        incidenceMatrix[i, edgeIndex] = adjMatrix[i, j];
                        incidenceMatrix[j, edgeIndex] = adjMatrix[i, j];
                        edgeIndex++;
                    }
                }
            }
            Console.WriteLine();
            int rows = incidenceMatrix.GetLength(0);
            int cols = incidenceMatrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(incidenceMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void SwapLetters()
        {
            string word = "listen";
            Queue<char> q = new Queue<char>();
            Stack<char> s = new Stack<char>();
            for (int i = 0; i < word.Length; i++)
            {
                q.Enqueue(word[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                s.Push(q.Dequeue());
            }
            for (int i = 0; i < 3; i++)
            {
                q.Enqueue(s.Pop());
            }
            s.Push(q.Dequeue());
            q.Enqueue(q.Dequeue());
            q.Enqueue(q.Dequeue());
            q.Enqueue(s.Pop());
            Console.WriteLine(string.Join("", q));

            string bgWord = "панер";
            Queue<char> qu = new Queue<char>();
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < bgWord.Length; i++)
            {
                qu.Enqueue(bgWord[i]);
            }
            qu.Enqueue(qu.Dequeue());
            st.Push(qu.Dequeue());
            st.Push(qu.Dequeue());
            st.Push(qu.Dequeue());
            qu.Enqueue(qu.Dequeue());
            qu.Enqueue(st.Pop());
            qu.Enqueue(st.Pop());
            qu.Enqueue(st.Pop());
            qu.Enqueue(qu.Dequeue());
            qu.Enqueue(qu.Dequeue());
            st.Push(qu.Dequeue());
            st.Push(qu.Dequeue());
            st.Push(qu.Dequeue());
            qu.Enqueue(st.Pop());
            qu.Enqueue(st.Pop());
            qu.Enqueue(st.Pop());
            Console.WriteLine(string.Join("", qu));

            string duma = "самолет";
            Queue<char> queue = new Queue<char>();
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < duma.Length; i++)
            {
                queue.Enqueue(duma[i]);
            }
            queue.Enqueue(queue.Dequeue());
            stack.Push(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(stack.Pop());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            stack.Push(queue.Dequeue());
            stack.Push(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(stack.Pop());
            queue.Enqueue(stack.Pop());
            Console.WriteLine(string.Join("", queue));
        }

        public static void TotoSport()
        {
            LinkedList<int> list = new LinkedList<int>();
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                list.AddLast(rand.Next(1, 100));
            }
            Console.WriteLine(string.Join(" ", list));
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list.ElementAt(i) >= 1 && list.ElementAt(i) <= 49)
                {
                    int numOfContains = 1;
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list.ElementAt(i) == list.ElementAt(j))
                        {
                            numOfContains++;
                        }
                    }
                    if (numOfContains == 1 && queue.Count < 6)
                    {
                        queue.Enqueue(list.ElementAt(i));
                    }
                }
            }
            Console.WriteLine(string.Join(" ", queue));
        }

        public static void NumberOfInversions()
        {
            int n = int.Parse(Console.ReadLine());
            if (n >= 5 && n <=105)
            {
                Random rand = new Random();
                List<int> list = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    list.Add(rand.Next(100,1000));
                }
                Console.WriteLine(string.Join(" ",list));
                bool isSorted = IsSortedIterative(list.ToArray());
                if (isSorted)
                {
                    Console.WriteLine("List is sorted");
                }
                else
                {
                    int inversions = GetNumberOfDirectInversions(list.ToArray());
                    Console.WriteLine($"The number of direct inverions are {inversions}");
                }
            }
        }

        private static bool IsSortedIterative(int[] array)
        {
            if (array.Length <= 1) return true;

            bool isAscending = true;//, isDescending = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1]) isAscending = false;
                //if (array[i] > array[i + 1]) isDescending = false;

                if (!isAscending /*&& !isDescending*/) return false;
            }
            return isAscending; //|| isDescending;
        }

        private static int GetNumberOfDirectInversions(int[] arr)
        {
            int invCounter = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    invCounter++;
                }
            }
            return invCounter;
        }

        public static void LinkedListInsertion()
        {
            LinkedList<int> list = new LinkedList<int>();
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.AddLast(rand.Next(10, 100));
            }
            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine();
            int x = -1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list.ElementAt(i) == list.ElementAt(j))
                    {
                        x = list.ElementAt(i);
                        break;
                    }
                }
                if (x != -1)
                {
                    break;
                }
            }
            Console.WriteLine(x);
            Console.WriteLine();
            LinkedListNode<int>? current = list.First;
            while (current != null)
            {
                LinkedListNode<int>? next = current.Next;
                if (current.Value > x)
                {
                    list.AddAfter(current, 0);
                }
                current = next;
            }
            Console.WriteLine(string.Join(" ", list));
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
