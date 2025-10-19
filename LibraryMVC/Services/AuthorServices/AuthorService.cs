using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.BaseServices;

namespace Services.AuthorServices
{
    public class AuthorService: BaseService
    {
        public async Task AddAuthor(string name, int age, DateOnly bd, string nationality)
        {
            Author author = new Author
            {
                Name = name,
                Age = age,
                BirthDate = bd,
                Nationality = nationality,
                DateLastModified = DateTime.Now
            };

            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAuthor(int id, string name, int age, DateOnly bd, string nationality)
        {
            var author = await context.Authors.FindAsync(id);
            author.DateLastModified = DateTime.Now;
            author.Name = name;
            author.Age = age;
            author.BirthDate = bd;
            author.Nationality = nationality;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int id)
        {
            var author = await context.Genres.FindAsync(id);
            author.DateLastModified = DateTime.Now;
            author.DateDeleted = DateTime.Now;
            author.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorByID(int id)
        {
            var author = await context.Authors.FindAsync(id);
            return author;
        }

        public async Task<List<Author>> GetAuthorsList()
        {
            var authors = await context.Authors.Where(x => x.IsDeleted == false).ToListAsync();
            return authors;
        }
    }
}
