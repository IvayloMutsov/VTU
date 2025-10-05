using AppDbContext.Data;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieRentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext appContext;

        public GenresController(ApplicationDbContext _context)
        {
            appContext = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await appContext.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreByID(int id)
        {
            var genres = await appContext.Genres.ToListAsync();
            var genre = genres.Find(x => x.ID == id);
            return Ok(genre);
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreByName(string name)
        {
            var genres = await appContext.Genres.ToListAsync();
            var genreByName = genres.FirstOrDefault(x => x.Name == name, new Genre { Name = name});
            return Ok(genreByName);
        }
    }
}
