using Microsoft.AspNetCore.Mvc;
using AppDbContext.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace MovieRentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DirectorsController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectors()
        {
            var directors = await context.Directors.ToListAsync();
            if (directors != null)
            {
                return Ok(directors);
            }
            else
            {
                return NotFound();
            }
        } 

        [HttpGet]
        public async Task<IActionResult> GetDirectorByID(int id)
        {
            var directors = await context.Directors.ToListAsync();
            var director = directors.Find(x => x.ID == id);
            if (director != null)
            {
                return Ok(director);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectorByName(string name)
        {
            var directors = await context.Directors.ToListAsync();
            var directorByName = directors.First(x => x.Name == name);
            if (directorByName != null)
            {
                return Ok(directorByName);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task AddDirector(string name)
        {
            var directors = await context.Directors.ToListAsync();
            int lastDirectorId = directors.Last().ID;
            using (context)
            {
                Director director = new Director { ID = lastDirectorId++, Name = name };
                context.Directors.Add(director);
                await context.SaveChangesAsync();
            }
        }
    }
}
