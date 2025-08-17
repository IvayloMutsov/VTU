using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOOP
{
    internal class Manager : Worker
    {
        public List<Employee> Workers { get; set; }
        public Manager(int id, string firstName, string lastName, int salary, string department) :
            base(id, firstName, lastName, salary, department)
        {
            Workers = new List<Employee>();
        }

        public void GetInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} - {Department},Manager : {Salary}");
        }

        public override int GetID()
        {
            return ID;
        }

        public void AddEmployee(Employee e)
        {
            if (Workers.Count < 10 && !Workers.Contains(e))
            {
                Workers.Add(e);
            }
        }

        public void RemoveEmployee(Employee e)
        {
            if (Workers.Contains(e))
            {
                Workers.Remove(e);
            }
        }

        public void UpdateEmployee(Employee e)
        {
            Console.Write("ID, FistName, LastName, Salary, Department, Position");
            string[] employeeChanges = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Employee empl = new Employee(int.Parse(employeeChanges[0]), employeeChanges[1], employeeChanges[2], int.Parse(employeeChanges[3]), employeeChanges[4], employeeChanges[5]);
            e = empl;
        }

        public void CreateEmployee()
        {
            Console.Write("ID, FistName, LastName, Salary, Department, Position");
            string[] employeeCreation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Employee employee = new Employee(int.Parse(employeeCreation[0]), employeeCreation[1], employeeCreation[2], int.Parse(employeeCreation[3]), employeeCreation[4], employeeCreation[5]);
            AddEmployee(employee);
        }
    }
}
