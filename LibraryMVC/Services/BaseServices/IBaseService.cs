using Database.Data;
using Infrastructure.Models;

namespace Services.BaseServices
{
    public interface IBaseService<T> where T : class
    {
        public Task Delete(int id);
        public Task<T> GetByID(int id);
        public Task<List<T>> GetList();
    }
}
