using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Services.GenreServices;
using Services.BaseServices;
using Microsoft.AspNetCore.Authorization;

namespace LibraryMVC.Controllers
{
    public class GenreController : Controller
    {
        IGenreService service;

        public GenreController(IGenreService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GenreView()
        {
            List<Genre> list = await service.GetList();
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
            Genre genre = await service.GetByID(id);
            if (genre == null)
            {
                return NotFound(); 
            }
            return View(genre);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGenre(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            await service.Add(name);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateGenre(int id, string name)
        {
            if (id == 0 || name == null)
            {
                return BadRequest();
            }
            await service.Update(id, name);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGenre(int id)
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
