using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Services.BaseServices;

namespace LibraryMVC.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService service;

        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorView()
        {
            List<Author> list = await service.GetList();
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
            Author author = await service.GetByID(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(string name, int age, DateOnly bd, string nationality)
        {
            if (name == null || age < 0 || bd == DateOnly.MinValue || nationality == null)
            {
                return BadRequest();
            }
            await service.Add(name, age, bd, nationality);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(int id, string name, int age, DateOnly bd, string nationality)
        {
            if (id ==0 || name == null || age < 0 || bd == DateOnly.MinValue || nationality == null)
            {
                return BadRequest();
            }
            await service.Update(id, name, age, bd, nationality);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAuthor(int id)
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
