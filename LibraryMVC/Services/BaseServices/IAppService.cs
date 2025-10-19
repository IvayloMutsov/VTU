namespace Services.BaseServices
{
    public interface IAppService
    {
        public Task GetAll();
        public Task GetByID(int id);
        public Task Add(string name);
        public Task Update(int id, string? name);
        public Task Delete(int id);
    }
}
