using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Database.Data;
using Infrastructure.AppUserModels;
using Services.BaseServices;
using Services.GenreServices;
using Services.AuthorServices;
using Services.BookServices;

namespace LibraryMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=LoginPage}/{id?}")
            .WithStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
