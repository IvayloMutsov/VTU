namespace Infrastructure.AppUserModels
{
    public class AdminUser: AppUser
    {
        public AdminUser()
        {
            this.Role.Name = "Admin";
        }
    }
}
