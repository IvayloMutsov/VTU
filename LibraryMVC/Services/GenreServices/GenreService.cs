using Services.BaseServices;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.GenreServices
{
    public class GenreService: BaseService
    {
        public async Task AddGenre(string name)
        {
            Genre genre = new Genre
            {
                Name = name,
                DateLastModified = DateTime.Now
            };

            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
        }

        public async Task UpdateGenre(int id, string name)
        {
            var genre = await context.Genres.FindAsync(id);
            genre.DateLastModified = DateTime.Now;
            genre.Name = name;
            await context.SaveChangesAsync();
        }

        public async Task DeleteGenre(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            genre.DateLastModified = DateTime.Now;
            genre.DateDeleted = DateTime.Now;
            genre.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<Genre> GetGenreByID(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            return genre;
        }

        public async Task<List<Genre>> GetGenresList()
        {
            var genres = await context.Genres.Where(x => x.IsDeleted == false).ToListAsync();
            return genres;
        }
    }
}
