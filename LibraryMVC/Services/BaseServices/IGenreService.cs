using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseServices
{
    public interface IGenreService : IBaseService<Genre>
    {
        public Task Add(string name);
        public Task Update(int id, string name);
        public Task<Genre> GetByID(int id);
        public Task<List<Genre>> GetList();
    }
}
