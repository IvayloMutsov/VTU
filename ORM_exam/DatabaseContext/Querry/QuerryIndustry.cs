using Infrastructure.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Querry
{
    public class QuerryIndustry
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public void Insert(string industryName)
        {
            using (context)
            {
                Industry industry = new Industry { IndustryName = industryName };
                context.industries.Add(industry);
                context.SaveChanges();
            }
        }

        public void Update(int id)
        {
            using (context)
            {
                Industry ind = context.industries.Find(id);
                Console.Write($"Modify Country {ind.IndustryName}: ");
                ind.IndustryName = Console.ReadLine();
                ind.DateModified = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                Website temp = context.websites.Find(id);
                SoftDelete del = new SoftDelete
                {
                    Name = temp.WebsiteName,
                    EntityState = State.Deleted.ToString()
                };
                context.deleted_records.Add(del);
                context.SaveChanges();
            }
        }

        public void GetAllWebsites()
        {
            var querry = from i in context.industries select i.IndustryName;
            foreach (var item in querry)
            {
                Console.WriteLine(item);
            }
        }
    }
}
