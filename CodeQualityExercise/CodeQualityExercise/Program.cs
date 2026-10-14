namespace CodeQualityExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = new List<int> { 1, 23, 71, 13, 25, 21, 29, 27, 99, 91, 31, 33, 0 };
            int searchdNumber = FindNum(listOfNumbers,0);
            Console.WriteLine(searchdNumber);
        }

        //Finds a specifc number in a list
        public static int FindNum(List<int> list, int id)
        {
            foreach (var i in list)
            {
                if (i == id)
                {
                    return i;
                }  
            }
            return -1; //return -1 if number is not found
        }
    }
}