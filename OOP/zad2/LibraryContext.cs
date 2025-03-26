using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Задайте тук вашата връзка към базата данни
            optionsBuilder.UseSqlServer("Server=DESKTOP-54VRF1R\\SQLEXPRESS;Database=RankDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
