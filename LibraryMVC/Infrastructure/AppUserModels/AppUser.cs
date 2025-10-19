using Microsoft.AspNetCore.Identity;

namespace Infrastructure.AppUserModels
{
    public abstract class AppUser: IdentityUser
    {
        public IdentityRole Role { get; set; }
    }
}
