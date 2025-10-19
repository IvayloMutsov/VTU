using Microsoft.AspNetCore.Identity;

namespace Infrastructure.AppUserModels
{
    public class AppUser: IdentityUser
    {
        public IdentityRole Role { get; set; }
    }
}
