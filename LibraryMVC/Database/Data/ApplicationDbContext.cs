using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=IVAYLO\\SQLEXPRESS;Database=aspnet-LibraryMVC;Trusted_Connection=True;TrustServerCertificate=True;");
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUserRole<string>>()
        .HasKey(r => new { r.UserId, r.RoleId });

        builder.Entity<IdentityUserRole<string>>()
            .HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<IdentityUserRole<string>>()
            .HasOne<IdentityRole>()
            .WithMany()
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
