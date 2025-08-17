using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOOP
{
    internal class WorkScheduler
    {
        private int managerId = 1;
        private int staffId = 1;
        public List<Worker> Staff { get; set; }
        public WorkScheduler()
        {
            Staff = new List<Worker>();
        }

        private void GetManagerByIDAndAsignEmployee(int id, Employee e)
        {
            Manager m = null;
            for (int i = 0; i < Staff.Count; i++)
            {
                if (Staff[i] is Manager && Staff[i].GetID() == id)
                {
                    m = Staff[i] as Manager;
                    m.AddEmployee(e);
                }
            }
        }

        public void GetEmplyeeWithMostWorkHours()
        {
            int hours = 0;
            Employee employee = null;
            for (int i = 0; i < Staff.Count; i++)
            {
                if (Staff[i] is Employee)
                {
                    employee = (Employee)Staff[i];
                    if (employee.GetWorkHours() > hours)
                    {
                        hours = employee.GetWorkHours();
                    }
                }
            }
            employee.GetInfo();
        }

        public void GetEmplyeeWithHighestSalary()
        {
            int salary = 0;
            Employee employee = null;
            for (int i = 0; i < Staff.Count; i++)
            {
                if (Staff[i] is Employee)
                {
                    employee = (Employee)Staff[i];
                    if (employee.GetSalary() > salary)
                    {
                        salary = employee.GetSalary();
                    }
                }
            }
            employee.GetInfo();
        }

        public void GetEmplyeeWithMostOvertimeWorked()
        {
            int overtime = 0;
            Dictionary<Employee,int> time = new Dictionary<Employee, int>();
            Employee e = null;
            for (int i = 0; i < Staff.Count; i++)
            {
                if (Staff[i] is Employee)
                {
                    e = (Employee)Staff[i];
                    if (e.GetWorkHours() > 8)
                    {
                        overtime = e.GetWorkHours() - 8;
                        time.Add(e,overtime);
                    }
                }
            }
            int maxOvertime = 0;
            foreach (var item in time)
            {
                if (item.Value > maxOvertime)
                {
                    maxOvertime = item.Value;
                }
            }
            foreach (var item in time)
            {
                if (item.Value == maxOvertime)
                {
                    Console.Write($"{item.Value} hours - ");
                    item.Key.GetInfo();
                }
            }
        }

        public void GetAllEmployeesUnderManager(Manager m)
        {
            foreach (Employee item in m.Workers)
            {
                item.GetInfo();
            }
        }

        public void CreateStaff(string[] cmd)
        {
            switch (cmd[0])
            {
                case "CreateManager": 
                    Manager m = new Manager(managerId, cmd[1], cmd[2], int.Parse(cmd[3]), cmd[4]);
                    Staff.Add(m); 
                    managerId++;
                    break;
                case "CreateRegular": 
                    Employee e = new Employee(staffId, cmd[1], cmd[2], int.Parse(cmd[3]), cmd[4], "Regular");
                    Staff.Add(e);
                    Console.Write("Under which manager does the employee work(ManagerID): ");
                    int bossID = int.Parse(Console.ReadLine());
                    GetManagerByIDAndAsignEmployee(bossID,e);
                    staffId++;
                    break;
                case "CreateMechanic":
                    Employee em = new Employee(staffId, cmd[1], cmd[2], int.Parse(cmd[3]), cmd[4], "Mechanic");
                    Staff.Add(em);
                    Console.Write("Under which manager does the employee work(ManagerID): ");
                    int bossId = int.Parse(Console.ReadLine());
                    GetManagerByIDAndAsignEmployee(bossId,em);
                    staffId++;
                    break;
                default: Console.WriteLine("Invalid command!");
                    break;
            }
        }

        public void CalculateEmployeeBonuses(Employee e)
        {
            double sal = e.GetSalary();
            if (e.GetPosition().Equals("Regular"))
            {
                if (e.GetWorkHours() > 8)
                {
                    sal *= 1.05;
                }
                if (e.GetOvertime() > 22)
                {
                    sal *= 1.1;
                }
            }
            else if (e.GetPosition().Equals("Mechanic"))
            {
                if (e.GetWorkHours() > 8)
                {
                    sal *= 1.1;
                }
                if (e.GetOvertime() > 22)
                {
                    sal *= 1.15;
                }
            }

            if (e.GetDayOfWeek() == DayOfWeek.Sunday || e.GetDayOfWeek() == DayOfWeek.Saturday)
            {
                sal *= 1.1;
            }

            Console.WriteLine(sal + e.CalculatePay());
        }
    }
}
