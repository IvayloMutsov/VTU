using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.BaseServices;

namespace LibraryMVC.Controllers
{
    public class SearchController : Controller
    {
        IBookService bookService;
        IAuthorService authorService;
        IGenreService genreService;
        IPublisherService publisherService;
        public SearchController(IBookService bookService, IAuthorService authorService, IGenreService genreService, IPublisherService publisherService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.genreService = genreService;
            this.publisherService = publisherService;
        }

        public async Task<IActionResult> SearchBookByName(string name)
        {
            var books = await bookService.GetList();
            var searchBooks = books.Where(x => x.Name.Contains(name)).ToList();
            return View(searchBooks);
        }

        public async Task<IActionResult> SearchAuthorByName(string name)
        {
            var authors = await authorService.GetList();
            var searchAuthors = authors.Where(x => x.Name.Contains(name)).ToList();
            return View(searchAuthors);
        }

        public async Task<IActionResult> SearchGenreByName(string name)
        {
            var genres = await genreService.GetList();
            var searchGenres = genres.Where(x => x.Name.Contains(name)).ToList();
            return View(searchGenres);
        }

        public async Task<IActionResult> SearchPublisherByName(string name)
        {
            var publishers = await publisherService.GetList();
            var searchPublishers = publishers.Where(x => x.Name.Contains(name)).ToList();
            return View(searchPublishers);
        }
    }
}
