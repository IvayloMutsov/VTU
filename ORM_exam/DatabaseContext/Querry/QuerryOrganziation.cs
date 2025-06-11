using Infrastructure.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext.Querry
{
    public class QuerryOrganziation
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public void Insert(string organizationName)
        {
            using (context)
            {
                Organization organization = new Organization { Name = organizationName };
                context.organizations.Add(organization);
                context.SaveChanges();
            }
        }

        public void Update(int id)
        {
            using (context)
            {
                Organization organization = context.organizations.Find(id);
                Console.Write($"Modify Country {organization.Name}: ");
                organization.Name = Console.ReadLine();
                organization.DateModified = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                Organization temp = context.organizations.Find(id);
                SoftDelete del = new SoftDelete
                {
                    Name = temp.Name,
                    EntityState = State.Deleted.ToString()
                };
                context.deleted_records.Add(del);
                context.SaveChanges();
            }
        }

        public void GetAllWebsites()
        {
            using (context)
            {
                var querry = from o in context.organizations select o.Name;
                foreach (var item in querry)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void OrganizationsByIndustries()
        {
            using (context)
            {
                var querry = from o in context.organizations group o by o.Industry into industryGroup select industryGroup;
                foreach (var item in querry)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void OrganizationsByNumOfEmployees()
        {
            using (context)
            {
                var querry = from o in context.organizations
                             where o.Numberofemployees > 1000
                             orderby o.Numberofemployees descending
                             select o;
                foreach (var item in querry)
                {
                    Console.WriteLine(item.Name + " " + item.Numberofemployees);
                }
            }
        }

        public void CompaniesByYearFounded()
        {
            string querry = "SELECT Name, Industry, Numberofemployees FROM organizations WHERE organizations.Founded < 2018 " +
                            "AND organizations.Founded > 1990";
            using (context)
            {
                context.Database.ExecuteSqlRaw(querry);
            }
        }
    }
}
