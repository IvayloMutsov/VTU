using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.ViewModels;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using Services.BaseServices;
namespace LibraryMVC.Controllers;

public class HomeController : Controller
{
    private IApplicationDbContext context;
    private ILoanService loanService;

    public HomeController(ILoanService loanService, IApplicationDbContext dbContext)
    {
        this.loanService = loanService;
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
        List<Author> authors = await context.Authors.OrderByDescending(x => x.TimesBookHasBeenLoaned).Take(3).ToListAsync();
        var loans = await context.BookLoans.Where(x => x.isReturned == false)
                                              .Include(x => x.Book)
                                              .Include(x => x.Book.Genre)
                                              .Include(x => x.Book.Author).ToListAsync();
        foreach(var item in loans)
        {
            loanService.ReturnLoan(item.ID);
        }
        StatisticsViewModel model = new StatisticsViewModel
        {
            FavouriteBooks = list,
            PopularAuthors = authors,
            ActiveLoans = loans.Where(x => x.isReturned == false).ToList()
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
