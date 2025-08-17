using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOOP
{
    internal abstract class Worker
    {
        protected int ID { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected int Salary { get; set; }
        protected string Department { get; set; }

        protected Worker(int id, string firstName, string lastName, int salary, string department)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Department = department;
        }

        public virtual int GetID()
        {
            return ID;
        }
    }
}