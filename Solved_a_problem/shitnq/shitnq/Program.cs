using System.Linq;

namespace shitnq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter input type( 1 is leters with numbers / 2 is only letters): ");
            int inputType = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            if(inputType == 1)
            {
                List<string> letters = input.Select(c => c.ToString()).ToList();
                List<int> counter = new List<int>();
                for(int i = 0; i < letters.Count; i++)
                {
                    if (int.TryParse(letters[i], out int num))
                    {
                        counter.Add(num);
                    }
                }
                for(int i = 0; i < letters.Count; i++)
                {
                    if (int.TryParse(letters[i], out int number))
                    {
                        if (counter.Contains(number))
                        {
                            letters.Remove(letters[i]);
                        }
                    }
                }
                for (int i = 0; i < counter.Count; i++)
                {
                    for (int j = 0; j < counter[i]; j++)
                    {
                        Console.Write(letters[i]);
                    }
                }
            }
            else if(inputType == 2)
            {
                List<char> list = new List<char>();
                List<int> counter = new List<int>();
                Dictionary<char, int> result = new Dictionary<char, int>();
                for (int i = 0; i < input.Length; i++)
                {
                    counter.Add(1);
                    if (list.Contains(input[i]))
                    {
                        counter[list.IndexOf(input[i])]++;
                    }
                    list.Add(input[i]);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (!counter.Contains(list[i]) && !result.ContainsKey(list[i]))
                    {
                        result.Add(list[i], counter[i]);
                    }
                }
                foreach (var item in result)
                {
                    Console.Write($"{item.Key}{item.Value}");
                }
            }
        }
    }
}