using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class LibraryService
    {
        private readonly LibraryContext _context;

        public LibraryService(LibraryContext context)
        {
            _context = context;
        }

        public void AddBook(string title, string author, int year, List<string> genres)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Year = year,
                Genres = genres,
                IsAvailable = true,
                TimesBorrowed = 0
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void RemoveBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return _context.Books.Where(b => b.Genres.Contains(genre)).ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author.Contains(author)).ToList();
        }

        public IEnumerable<Book> GetBooksByYear(int year)
        {
            return _context.Books.Where(b => b.Year == year).ToList();
        }

        public void BorrowBook(int userId, int bookId)
        {
            var user = _context.Users.Include(u => u.BorrowedBooks).FirstOrDefault(u => u.Id == userId);
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if (user != null && book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                user.BorrowedBooks.Add(book);
                book.TimesBorrowed++;

                _context.SaveChanges();
            }
        }

        public void ReturnBook(int userId, int bookId)
        {
            var user = _context.Users.Include(u => u.BorrowedBooks).FirstOrDefault(u => u.Id == userId);
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if (user != null && book != null)
            {
                user.BorrowedBooks.Remove(book);
                book.IsAvailable = true;

                _context.SaveChanges();
            }
        }

        public int GetBookBorrowCount(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            return book?.TimesBorrowed ?? 0;
        }

        public bool IsBookAvailable(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            return book?.IsAvailable ?? false;
        }

        public IEnumerable<Book> GetBorrowedBooks(int userId)
        {
            var user = _context.Users.Include(u => u.BorrowedBooks).FirstOrDefault(u => u.Id == userId);
            return user?.BorrowedBooks ?? new List<Book>();
        }
    }
}
