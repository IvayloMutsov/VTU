using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOOP
{
    internal class Employee : Worker
    {
        private string Position { get; set; }
        private DateTime[] WorkHours { get; set; }
        public Employee(int id, string firstName, string lastName, int salary, string department, string position) :
            base(id, firstName, lastName, salary, department)
        {
            Position = position;
            WorkHours = new DateTime[2];
        }

        public override int GetID()
        {
            return ID;
        }

        public string GetPosition()
        {
            return Position;
        }

        public int GetOvertime()
        {
            return WorkHours[1].Hour;
        }

        public DayOfWeek GetDayOfWeek()
        {
            return WorkHours[0].DayOfWeek;
        }

        public int GetWorkHours()
        {
            if (WorkHours[0] == default || WorkHours[1] == default)
            {
                Console.WriteLine("The employee has not worked yet!");
                return 0;
            }
            else
            {
                int workTime = WorkHours[1].Hour - WorkHours[0].Hour;
                return workTime;
            }
        }

        public void ComeOrLeaveWork(string[] cmd)
        {
            if (int.Parse(cmd[1]) == ID)
            {
                if (cmd[0] == "SetIn")
                {
                    WorkHours[0] = DateTime.Parse(cmd[2]);
                }
                else if (cmd[0] == "SetOut")
                {
                    WorkHours[1] = DateTime.Parse(cmd[2]);
                }
                else
                {
                    Console.WriteLine("Invalid Command!");
                }
            }
            else
            {
                Console.WriteLine("Wrong Employee!");
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} - {Department},{Position} : {Salary}");
        }

        public int CalculatePay()
        {
            int workHours = GetWorkHours();
            int pay = Salary * workHours;
            return pay;
        }

        public int GetSalary()
        {
            return Salary;
        }
    }
}
