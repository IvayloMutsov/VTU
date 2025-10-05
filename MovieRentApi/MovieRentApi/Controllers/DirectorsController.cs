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
            return Ok(directors);
        } 

        [HttpGet]
        public async Task<IActionResult> GetDirectorByID(int id)
        {
            var directors = await context.Directors.ToListAsync();
            var director = directors.Find(x => x.ID == id);
            return Ok(director);
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectorByName(string name)
        {
            var directors = await context.Directors.ToListAsync();
            var directorByName = directors.FirstOrDefault(x => x.Name == name,new Director { Name = name});
            return Ok(directorByName);
        }
    }
}
