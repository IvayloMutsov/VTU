using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public class Sorting
    {
        public static int[] C = new int[2000000];

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

        public static void HeapSort(int[] data)
        {
            int n = data.Length;
            for(int i = n / 2; i >= 0; i--)
            {
                Sift(data, i, n - 1);
            }
            int size = n - 1;
            while (size > 0)
            {
                int temp = data[0];
                data[0] = data[size];
                data[size] = temp;
                size--;
                Sift(data, 0, size);
            }
        }

        private static void Sift(int[] data, int v, int r) //Used in Heap sort
        {
            int i = v, j = (2 * i) + 1;
            int x = data[i];
            if (j < r && data[j + 1] > data[j])
            {
                j++;
            }
            while (j <= r && data[j] > x)
            {
                data[i] = data[j]; 
                i = j;
                j = (2 * i) + 1;
                if (j < r && data[j + 1] > data[j])
                {
                    j++;
                }   
            }
            data[i] = x;
        }

        public static void QuickSort(int[] data, int left, int right)
        {
            int i = left, j = right, x = data[(left + right) / 2];
            do
            {
                while (data[i] < x)
                {
                    i++;
                }
                while (data[j] > x)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j)
            {
                QuickSort(data,left,j);
            }
            if (i < right)
            {
                QuickSort(data, i, right);
            }
        }

        public static void MergeSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(data, left, mid);
                MergeSort(data, mid + 1, right);
                Merge(data, left, mid, right);
            }
        }

        private static void Merge(int[] data, int left, int mid, int right)
        {
            int i = left, j = mid + 1, k = 0;
            while (i <= mid && j <= right)
            {
                if (data[i] < data[j])
                {
                    C[k++] = data[i++];
                }
                else
                {
                    C[k++] = data[j++];
                }
            }
            if (i > mid)
            {
                while (j <= right)
                {
                    C[k++] = data[j++];
                }
            }
            else
            {
                while (i <= mid)
                {
                    C[k++] = data[i++];
                }
            }
            for (i = 0; i < k; i++)
            {
                data[left + i] = C[i];
            }
        }

        //just a random zadacha
        public static bool NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i < 0) 
            {
                return false;
            }
            int j = nums.Length - 1;
            while (nums[j] <= nums[i])
            {
                j--;
            }
            (nums[i], nums[j]) = (nums[j], nums[i]);
            Array.Reverse(nums, i + 1, nums.Length - (i + 1));
            return true;
        }

        public static bool IsHeap(int[] data)
        {
            bool isHeap = false;
            int n = data.Length / 2 - 1;
            for (int i = 0; i < n; i++)
            {
                if (data[2*i + 1] < data[i] && data[2*i + 2] < data[i])
                {
                    isHeap = true;
                }
                else
                {
                    isHeap = false;
                }
            }
            return isHeap;
        }

        public static void StalinSort()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(7);
            list.AddLast(3);
            list.AddLast(9);
            list.AddLast(6);
            list.AddLast(11);
            list.AddLast(5);
            list.AddLast(12);
            list.AddLast(14);
            list.AddLast(8);
            LinkedListNode<int> it = list.First;
            LinkedListNode<int> it2 = it.Next;
            while (it != list.Last)
            {
                if (it.Value > it2.Value)
                {
                    LinkedListNode<int> temp = it2.Next;
                    list.Remove(it2);
                    it2 = temp;
                }
                else
                {
                    it = it.Next;
                    it2 = it2.Next;
                }
            }
            Console.WriteLine(string.Join(" ",list));
        }
    }
}