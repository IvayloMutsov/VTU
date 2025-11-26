using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseServices
{
    public interface IPublisherService : IBaseService<Publisher>
    {
        public Task Add(string name, string city, string country, string email, int yearFounded);
        public Task Update(int id, string name, string city, string country, string email, int yearFounded);
        public Task<Publisher> GetByID(int id);
        public Task<List<Publisher>> GetList();
    }
}
