using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BaseServices;

namespace LibraryMVC.Controllers
{
    public class PublisherController : Controller
    {
        IPublisherService service;

        public PublisherController(IPublisherService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> PublisherView()
        {
            List<Publisher> list = await service.GetList();
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
            Publisher p = await service.GetByID(id);
            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPublisher(string name, string city, string country, string email, int yearFounded)
        {
            if (name == null || city == null || country == null || email == null || yearFounded == 0)
            {
                return BadRequest();
            }
            await service.Add(name, city, country, email, yearFounded);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePublisher(int id, string name, string city, string country, string email, int yearFounded)
        {
            if (id == 0 || name == null || city == null || country == null || email == null || yearFounded == 0)
            {
                return BadRequest();
            }
            await service.Update(id, name, city, country, email, yearFounded);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePublisher(int id)
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
