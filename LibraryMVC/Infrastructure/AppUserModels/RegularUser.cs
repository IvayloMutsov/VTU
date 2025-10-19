namespace Infrastructure.AppUserModels
{
    public class RegularUser: AppUser
    {
        public RegularUser()
        {
            this.Role.Name = "Regular";
        }
    }
}
