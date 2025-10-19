using Database.Data;

namespace Services.BaseServices
{
    public abstract class BaseService
    {
        protected ApplicationDbContext context { get; set; }
    }
}
