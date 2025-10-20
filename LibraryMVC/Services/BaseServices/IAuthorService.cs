using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseServices
{
    public interface IAuthorService : IBaseService<Author>
    {
        public Task Add(string name, int age, DateOnly bd, string nationality);
        public Task Update(int id, string name, int age, DateOnly bd, string nationality);
        public Task<Author> GetByID(int id);
        public Task<List<Author>> GetList();
    }
}
