namespace OOPoldHWzad3
{
    // Custom generic exception class for invalid range
    public class InvalidRangeException<T> : Exception
    {
        public T RangeStart { get; }
        public T RangeEnd { get; }

        // Constructor that initializes the exception message, range start, and range end
        public InvalidRangeException(string message, T rangeStart, T rangeEnd)
            : base(message)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }

        // Method to display the details of the exception
        public override string ToString()
        {
            return $"{base.ToString()} (Range: {RangeStart} - {RangeEnd})";
        }
    }

    public class Program
    {
        // Method to validate integer within range [1, 100]
        public static void ValidateIntegerRange(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new InvalidRangeException<int>("Number is out of range", 1, 100);
            }
        }

        // Method to validate DateTime within range [01.01.1980, 31.12.2013]
        public static void ValidateDateTimeRange(DateTime date)
        {
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);
            if (date < startDate || date > endDate)
            {
                throw new InvalidRangeException<DateTime>("Date is out of range", startDate, endDate);
            }
        }

        // Main program
        public static void Main()
        {
            // Handle integer range validation
            Console.WriteLine("Enter an integer between 1 and 100:");
            int number = int.Parse(Console.ReadLine());
            try
            {
                ValidateIntegerRange(number);
                Console.WriteLine($"You entered a valid number: {number}");
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex);
            }

            // Handle DateTime range validation
            Console.WriteLine("\nEnter a date in the format (dd/MM/yyyy) between 01.01.1980 and 31.12.2013:");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            try
            {
                ValidateDateTimeRange(date);
                Console.WriteLine($"You entered a valid date: {date.ToShortDateString()}");
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
