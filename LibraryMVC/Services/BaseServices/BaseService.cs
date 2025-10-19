using Database.Data;

namespace Services.BaseServices
{
    public abstract class BaseService : IAppService
    {
        protected ApplicationDbContext context { get; set; }

        public virtual async Task Add(string name){}

        public virtual async Task Delete(int id){}

        public virtual async Task GetAll(){}

        public virtual async Task GetByID(int id){}

        public virtual async Task Update(int id, string? name){}
    }
}
