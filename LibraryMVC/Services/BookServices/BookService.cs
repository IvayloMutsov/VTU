using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.AuthorServices;
using Services.BaseServices;
using Services.GenreServices;

namespace Services.BookServices
{
    public class BookService: BaseService
    {
        private GenreService genreService;
        private AuthorService authorService;

        public async Task AddBook(string name, int genreID, int authorID)
        {
            Book book = new Book
            {
                Name = name,
                DateLastModified = DateTime.Now,
                Genre = await genreService.GetGenreByID(genreID),
                Author = await authorService.GetAuthorByID(authorID)
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBook(int id, string name, int genreID, int authorID)
        {
            var book = await context.Books.FindAsync(id);
            book.DateLastModified = DateTime.Now;
            book.Name = name;
            book.Genre = await genreService.GetGenreByID(genreID);
            book.Author = await authorService.GetAuthorByID(authorID);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await context.Books.FindAsync(id);
            book.DateLastModified = DateTime.Now;
            book.DateDeleted = DateTime.Now;
            book.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<Genre> GetBookByID(int id)
        {
            var book = await context.Genres.FindAsync(id);
            return book;
        }

        public async Task<List<Book>> GetBooksList()
        {
            var books = await context.Books.Where(x => x.IsDeleted == false).ToListAsync();
            return books;
        }
    }
}
