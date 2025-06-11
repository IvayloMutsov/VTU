using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        private string connectionString = "Server=IVAYLO\\SQLEXPRESS;Database=Organizations;Trusted_Connection=True;TrustServerCertificate = True;";

        public DbSet<Organization> organizations { get; set; }

        public DbSet<Country> counties { get; set; }

        public DbSet<Website> websites { get; set; }

        public DbSet<Industry> industries { get; set; }

        public DbSet<SoftDelete> deleted_records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
