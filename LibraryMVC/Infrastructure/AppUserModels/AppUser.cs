using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.AppUserModels
{
    public class AppUser: IdentityUser
    {
        public IdentityRole Role { get; set; }

        public List<Book> BooksRented { get; set; }
    }
}
