using Database.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.AuthorServices;
using Services.BaseServices;
using Services.GenreServices;

namespace Services.BookServices
{
    public class BookService: IBookService
    {
        private ApplicationDbContext context;
        private IGenreService genreService;
        private IAuthorService authorService;

        public BookService(ApplicationDbContext context, IGenreService genreService, IAuthorService authorService)
        {
            this.context = context;
            this.genreService = genreService;
            this.authorService = authorService;
        }

        public async Task Add(string name, int genreID, int authorID)
        {
            Book book = new Book
            {
                Name = name,
                DateLastModified = DateTime.Now,
                Genre = await genreService.GetByID(genreID),
                Author = await authorService.GetByID(authorID)
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, string name, int genreID, int authorID)
        {
            var book = await context.Books.FindAsync(id);
            book.DateLastModified = DateTime.Now;
            book.Name = name;
            book.Genre = await genreService.GetByID(genreID);
            book.Author = await authorService.GetByID(authorID);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await context.Books.FindAsync(id);
            book.DateLastModified = DateTime.Now;
            book.DateDeleted = DateTime.Now;
            book.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<Book> GetByID(int id)
        {
            var book = await context.Books.FindAsync(id);
            return book;
        }

        public async Task<List<Book>> GetList()
        {
            var books = await context.Books.Where(x => x.IsDeleted == false)
                                           .Include(b => b.Author)
                                           .Include(b => b.Genre).ToListAsync();
            return books;
        }
    }
}
