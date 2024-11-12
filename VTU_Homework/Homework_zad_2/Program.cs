namespace Homework_zad_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of boxes: ");
            int numverOfBoxes = int.Parse(Console.ReadLine());
            if (numverOfBoxes > 40 || numverOfBoxes < 1)
            {
                Console.WriteLine("You cannot have more than 40 or less than 1 boxes");

            }
            else
            {
                int yellowApplesCount = 0;
                int redApplesCount = 0;
                int appleDifference;
                for (int i = 1; i <= numverOfBoxes; i++)
                {
                    if (i % 2 == 0)
                    {
                        redApplesCount += i * i;
                    }
                    else
                    {
                        yellowApplesCount += i * i;
                    }
                }
                appleDifference = yellowApplesCount - redApplesCount;
                Console.WriteLine($"The difference between yellow and red apples is {appleDifference}");
            }
        }
    }
}
