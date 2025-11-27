using Database.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.BaseServices;

namespace Services.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        IApplicationDbContext context;

        public PublisherService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(string name, string city, string country, string email, int yearFounded)
        {
            Publisher p = new Publisher
            {
                Name = name,
                City = city,
                Country = country,
                Email = email,
                YearFounded = yearFounded
            };
            await context.Publishers.AddAsync(p);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var p = await context.Publishers.FindAsync(id);
            p.DateLastModified = DateTime.Now;
            p.DateDeleted = DateTime.Now;
            p.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<Publisher> GetByID(int id)
        {
            var p = await context.Publishers.FindAsync(id);
            return p;
        }

        public async Task<List<Publisher>> GetList()
        {
            var p = await context.Publishers.Where(x => x.IsDeleted == false).ToListAsync();
            return p;
        }

        public async Task Update(int id, string name, string city, string country, string email, int yearFounded)
        {
            var p = await context.Publishers.FindAsync(id);
            p.Name = name;
            p.City = city;
            p.Country = country;
            p.Email = email;
            p.YearFounded = yearFounded;
            await context.SaveChangesAsync();
        }
    }
}
