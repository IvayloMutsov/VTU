using Services.BaseServices;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Database.Data;
using Services.AuthorServices;

namespace Services.GenreServices
{
    public class GenreService: IGenreService
    {
        private IApplicationDbContext context;

        public GenreService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(string name)
        {
            Genre genre = new Genre
            {
                Name = name,
                DateLastModified = DateTime.Now
            };

            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, string name)
        {
            var genre = await context.Genres.FindAsync(id);
            genre.DateLastModified = DateTime.Now;
            genre.Name = name;
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            genre.DateLastModified = DateTime.Now;
            genre.DateDeleted = DateTime.Now;
            genre.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<Genre> GetByID(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            return genre;
        }

        public async Task<List<Genre>> GetList()
        {
            var genres = await context.Genres.Where(x => x.IsDeleted == false).ToListAsync();
            return genres;
        }
    }
}
