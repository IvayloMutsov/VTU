using Database.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.BaseServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Services.BookServices
{
    public class BookService: IBookService
    {
        private IApplicationDbContext context;
        private IGenreService genreService;
        private IAuthorService authorService;
        private IPublisherService publisherService;
        private readonly IWebHostEnvironment _env;

        public BookService(IApplicationDbContext context, IGenreService genreService, IAuthorService authorService, IPublisherService publisherService, IWebHostEnvironment env)
        {
            this.context = context;
            this.genreService = genreService;
            this.authorService = authorService;
            this.publisherService = publisherService;
            _env = env;

        }

        public async Task Add(string name, int genreID, int authorID, int publisherID, int yearPublished, IFormFile imageFile)
        {
            string imageFileName = await SaveImageFile(imageFile);

            Book book = new Book
            {
                Name = name,
                DateLastModified = DateTime.Now,
                Genre = await genreService.GetByID(genreID),
                Author = await authorService.GetByID(authorID),
                Publisher = await publisherService.GetByID(publisherID),
                YearPublished = yearPublished,
                ImageFileName = imageFileName
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, string name, int genreID, int authorID, int publisherID, int yearPublished, IFormFile imageFile)
        {
            var book = await context.Books.FindAsync(id);

            book.Name = name;
            book.Genre = await genreService.GetByID(genreID);
            book.Author = await authorService.GetByID(authorID);
            book.Publisher = await publisherService.GetByID(publisherID);
            book.YearPublished = yearPublished;
            book.DateLastModified = DateTime.Now;

            if (imageFile != null && imageFile.Length > 0)
            {
                string newFileName = await SaveImageFile(imageFile);
                book.ImageFileName = newFileName;
            }

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
            var book = await context.Books.Where(b => b.ID == id && b.IsDeleted == false)
                            .Include(b => b.Genre)
                            .Include(b => b.Author)
                            .Include(b => b.Publisher)
                            .FirstOrDefaultAsync();
            return book;
        }

        public async Task<List<Book>> GetList()
        {
            var books = await context.Books.Where(x => x.IsDeleted == false)
                                           .Include(b => b.Author)
                                           .Include(b => b.Genre)
                                           .Include(b => b.Publisher).ToListAsync();
            return books;
        }

        private async Task<string> SaveImageFile(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            string folder = Path.Combine(_env.WebRootPath, "images/books");
            Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            string path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
