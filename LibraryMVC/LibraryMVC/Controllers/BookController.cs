using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BaseServices;

namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BookView()
        {
            List<Book> list = await service.GetList();
            if (list.Count == 0)
            {
                return NoContent();
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> SearchById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Book book = await service.GetByID(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook(string name, int genreID, int authorID, int publisherID, int yearPublished)
        {
            if (name == null || genreID == 0 || authorID == 0 || publisherID == 0)
            {
                return BadRequest();
            }
            await service.Add(name, genreID, authorID, publisherID, yearPublished);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(int id, string name, int genreID, int authorID, int publisherID, int yearPublished)
        {
            if (id == 0 || name == null || genreID == 0 || authorID == 0 || publisherID == 0)
            {
                return BadRequest();
            }
            await service.Update(id, name, genreID, authorID,publisherID, yearPublished);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await service.Delete(id);
            return PartialView("_TaskCompleted");
        }
    }
}
