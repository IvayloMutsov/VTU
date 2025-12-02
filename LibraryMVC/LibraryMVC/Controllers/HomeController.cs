using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.ViewModels;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
namespace LibraryMVC.Controllers;

public class HomeController : Controller
{
    private IApplicationDbContext context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IApplicationDbContext dbContext)
    {
        _logger = logger;
        context = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult LoginPage()
    {
        return View();
    }

    public async Task<IActionResult> Statistics()
    {
        List<Book> list = await context.Books.OrderByDescending(x => x.TimesLoaned)
                                             .Include(x => x.Genre)
                                             .Include(x => x.Author)
                                             .Include(x => x.Publisher)
                                             .Take(3).ToListAsync();
        StatisticsViewModel model = new StatisticsViewModel
        {
            FavouriteBooks = list
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
