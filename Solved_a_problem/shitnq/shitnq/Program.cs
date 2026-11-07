using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace shitnq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new LibraryContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.WriteLine("===== A =====");
            var resultA = db.Books.ToList().Where(x => x.Title.StartsWith("D")).Take(2).ToList();

            Console.WriteLine("===== B =====");
            var resultB = db.Books.Where(x => x.Title.StartsWith("D")).Take(2).ToList();

            Console.WriteLine("===== C =====");
            IEnumerable<Book> allBooks = db.Books;
            var resultC = allBooks.Where(x => x.Title.StartsWith("D")).Take(2).ToList();

            Console.WriteLine("===== D =====");
            // TODO: page 3 of the books list, 2 books per page, ordered by Title
            var resultD = db.Books.OrderBy(x => x.Title).Skip(4).Take(2).ToList();
        }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Book> Books { get; set; } = new();
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int AuthorId { get; set; }
    }

    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EfInterviewTest;Trusted_Connection=True;TrustServerCertificate=True")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}