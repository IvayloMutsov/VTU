using Microsoft.EntityFrameworkCore;
using MoviesDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDB
{
    public class MoviesDBcontext : DbContext
    {
        private string connectionString = "Server=IVAYLO\\SQLEXPRESS;Database=Movies;Trusted_Connection=True;TrustServerCertificate = True;";

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Cast> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
