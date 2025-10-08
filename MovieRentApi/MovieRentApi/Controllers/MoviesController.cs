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
            var movies = await context.Movies.Where(x => x.IsDeleted == false).ToListAsync();
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

        [HttpPost]
        public async Task<IActionResult> AddMovie(string name, int duration, int releaseDate, double rating, int directorId, int genreId)
        {
            using (context)
            {
                var genres = await context.Genres.ToListAsync();
                Genre genre = genres.Find(x => x.ID == genreId);

                var directors = await context.Directors.ToListAsync();
                Director director = directors.Find(x => x.ID == directorId);

                if (genre == null || director == null)
                {
                    return NotFound();
                }
                else
                {
                    Movie movie = new Movie
                    {
                        Name = name,
                        Duration = duration,
                        ReleaseDate = releaseDate,
                        Rating = rating,
                        Genre = genre,
                        Director = director,
                    };

                    await context.Movies.AddAsync(movie);
                    await context.SaveChangesAsync();
                    return Ok(movie);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovies(int id, string name, int duration, int releaseDate, double rating)
        {
            var movies = await context.Movies.ToListAsync();
            var movie = movies.Find(x => x.ID == id);
            if (movie != null)
            {
                movie.Name = name;
                movie.Duration = duration;
                movie.ReleaseDate = releaseDate;
                movie.Rating = rating;
                movie.DateLastModified = DateTime.Now;

                context.Movies.Update(movie);
                await context.SaveChangesAsync();

                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movies = await context.Movies.ToListAsync();
            var movie = movies.Find(x => x.ID == id);
            if (movie == null)
            {
                return NotFound(); 
            }
            else
            {
                movie.IsDeleted = true;
                movie.DateLastModified = DateTime.Now;
                FakeDelete del = new FakeDelete { EntityID = id, Name = movie.Name, IsDeleted = true };
                await context.SoftDelete.AddAsync(del);
                context.Movies.Update(movie);
                await context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
