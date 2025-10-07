using AppDbContext.Data;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            if (genres != null)
            {
                return Ok(genres);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreByID(int id)
        {
            var genres = await appContext.Genres.ToListAsync();
            var genre = genres.Find(x => x.ID == id);
            if (genre != null)
            {
                return Ok(genre);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreByName(string name)
        {
            var genres = await appContext.Genres.ToListAsync();
            var genreByName = genres.First(x => x.Name == name);
            if (genreByName != null)
            {
                return Ok(genreByName);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task AddGenre(string name)
        {
            var genres = await appContext.Genres.ToListAsync();
            int lastGenreId = genres.Last().ID;
            using (appContext)
            {
                Genre newGenre = new Genre { ID = lastGenreId++, Name = name };
                appContext.Genres.Add(newGenre);
                await appContext.SaveChangesAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGenre(int id, string name)
        {
            var genres = await appContext.Genres.ToListAsync();
            var genre = genres.Find(x => x.ID == id);
            if (genre != null)
            {
                genre.Name = name;
                genre.DateLastModified = DateTime.Now;
                appContext.Genres.Update(genre);
                await appContext.SaveChangesAsync();
                return Ok(genre);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
