namespace CourseWorkOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WorkScheduler scheduler = new WorkScheduler();
            string[] input = new string[5];
            while (!input.Contains("end"))
            {
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0].Contains("Create"))
                {
                    scheduler.CreateStaff(input);
                }
                if (input[0].Contains("Set"))
                {
                    Employee employee = scheduler.Staff.OfType<Employee>().FirstOrDefault(x => x.GetID() == int.Parse(input[1]));
                    employee.ComeOrLeaveWork(input);
                }
            }
            Console.WriteLine("Most work hourrs");
            scheduler.GetEmplyeeWithMostWorkHours();
            Console.WriteLine("Best salary");
            scheduler.GetEmplyeeWithHighestSalary();
            Console.WriteLine("Most overtime");
            scheduler.GetEmplyeeWithMostOvertimeWorked();
            Console.WriteLine("Iterate over each staff mamber");
            for (int i = 0; i < scheduler.Staff.Count; i++)
            {
                if (scheduler.Staff[i] is Manager)
                {
                    Manager m = (Manager)scheduler.Staff[i];
                    Console.WriteLine("Manager " + m.GetID());
                    m.GetInfo();
                    Console.WriteLine("Employees under this manager");
                    scheduler.GetAllEmployeesUnderManager(m);
                    m.RemoveEmployee(m.Workers[1]);
                    m.UpdateEmployee(m.Workers[0]);
                    m.CreateEmployee();
                    scheduler.GetAllEmployeesUnderManager(m);
                }
                else if (scheduler.Staff[i] is Employee)
                {
                    Employee e = (Employee)scheduler.Staff[i];
                    Console.WriteLine("Employee " + e.GetID());
                    Console.WriteLine(e.GetWorkHours());
                    Console.WriteLine(e.GetPosition());
                    Console.WriteLine(e.GetSalary());
                    scheduler.CalculateEmployeeBonuses(e);
                }
            }
        }
    }
}
