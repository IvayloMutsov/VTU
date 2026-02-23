using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public class Zadacha
    {
        public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            if (n <= 23)
            {
                int daysA = 0;
                int daysB = 0;
                int daysC = 0;
                int[] A = new int[n];
                int[] B = new int[n];
                int[] C = new int[n];
                Input(A);
                Input(B);
                Input(C);
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] > 25)
                    {
                        daysA++;
                    }
                }
                Console.WriteLine($"Days A had more than 25 : {daysA}");
                for (int i = 0; i < B.Length; i++)
                {
                    if (B[i] > 25)
                    {
                        daysB++;
                    }
                }
                Console.WriteLine($"Days B had more than 25 : {daysB}");
                for (int i = 0; i < C.Length; i++)
                {
                    if (C[i] > 25)
                    {
                        daysC++;
                    }
                }
                Console.WriteLine($"Days C had more than 25 : {daysC}");
                Console.Write("Days A had more than the everage: ");
                Output(A);
                Console.Write("Days B had more than the everage: ");
                Output(B);
                Console.Write("Days C had more than the everage: ");
                Output(C);
                Console.Write("Min-Max for A: ");
                MinMax(A);
                Console.Write("Min-Max for B: ");
                MinMax(B);
                Console.Write("Min-Max for C: ");
                MinMax(C);
            }
            else
            {
                Console.WriteLine("Invalid input: Number must be less than or equal to 23!");
            }
        }

        private void Input(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0,31);
            }
        }

        private void Output(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            int avg = sum / arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > avg)
                {
                    Console.Write($"{i + 1} ");
                }
            }
            Console.WriteLine();
        }

        private void MinMax(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                else if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine($"The max is {max} and min is {min}");
        }
    }
}
