using Infrastructure;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Querry
{
    public class QuerryCountries
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public void Insert(string countryName)
        {
            using (context)
            {
                Country country = new Country { CountryName = countryName };
                context.counties.Add(country);
                context.SaveChanges();
            }
        }

        public void Update(int id)
        {
            using (context)
            {
                Country co = context.counties.Find(id);
                Console.Write($"Modify Country {co.CountryName}: ");
                co.CountryName = Console.ReadLine();
                co.DateModified = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                Country temp = context.counties.Find(id);
                SoftDelete del = new SoftDelete
                {
                    Name = temp.CountryName,
                    EntityState = State.Deleted.ToString()
                };
                context.deleted_records.Add(del);
                context.SaveChanges();
            }
        }

        public void GetAllCountries()
        {
            using (context)
            {
                var querry = from c in context.counties select c.CountryName;

                foreach (var item in querry)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void CountriesByIndustriesAndNumOfCompanies()
        {
            using (context)
            {
                var querry = from c in context.counties
                             join o in context.organizations on c.Id equals o.Country.Id
                             join i in context.industries on o.Industry.Id equals i.Id
                             select c;
                foreach (var item in querry)
                {
                    Console.WriteLine(item.CountryName);
                }
            }

        }
    }
}
