using Infrastructure.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Querry
{
    public class QuerryWebsites
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public void Insert(string websiteName)
        {
            using (context)
            {
                Website website = new Website { WebsiteName = websiteName };
                context.websites.Add(website);
                context.SaveChanges();
            }
        }

        public void Update(int id)
        {
            using (context)
            {
                Website web = context.websites.Find(id);
                Console.Write($"Modify Country {web.WebsiteName}: ");
                web.WebsiteName = Console.ReadLine();
                web.DateModified = DateTime.Now;
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
            var querry = from w in context.websites select w.WebsiteName;
            foreach (var item in querry)
            {
                Console.WriteLine(item);
            }
        }
    }
}
