using Microsoft.AspNetCore.Mvc;
using AppDbContext.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MoviesController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await context.Movies.ToListAsync();
            if (movies != null)
            {
                return Ok(movies);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieByID(int id)
        {
            var movies = await context.Movies.ToListAsync();
            var movie = movies.Find(x => x.ID == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieByName(string name)
        {
            var movies = await context.Movies.ToListAsync();
            var movieByName = movies.First(x => x.Name == name);
            if (movieByName != null)
            {
                return Ok(movieByName);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
