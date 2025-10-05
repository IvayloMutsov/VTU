using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDbContext.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string connectionString = "Server=IVAYLO\\SQLEXPRESS;Database=WebMovies;Trusted_Connection=True;TrustServerCertificate = True;";

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<FakeDelete> SoftDelete { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
