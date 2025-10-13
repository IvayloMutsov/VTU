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
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext appContext;

        public GenreController(ApplicationDbContext _context)
        {
            appContext = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await appContext.Genres.Where(x => x.IsDeleted == false).ToListAsync();
            if (genres != null)
            {
                return Ok(genres);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("id")]
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

        [HttpGet("name")]
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

        [HttpPost("add")]
        public async Task<IActionResult> AddGenre(string name)
        {
            using (appContext)
            {
                Genre newGenre = new Genre { Name = name };
                await appContext.Genres.AddAsync(newGenre);
                await appContext.SaveChangesAsync();
                return Ok(newGenre);
            }
        }

        [HttpPost("update")]
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

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genres = await appContext.Genres.ToListAsync();
            var genreDelete = genres.Find(x => x.ID == id);
            if (genreDelete == null)
            {
                return NotFound();
            }
            else
            {
                FakeDelete del = new FakeDelete { EntityID = id, Name = genreDelete.Name, IsDeleted = true };
                genreDelete.IsDeleted = true;
                genreDelete.DateLastModified = DateTime.Now;
                await appContext.SoftDelete.AddAsync(del);
                appContext.Genres.Update(genreDelete);
                await appContext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
