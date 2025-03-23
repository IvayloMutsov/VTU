using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public enum UserType
    {
        Regular,
        Special,
        Golden
    }

    public class User
    {
        private readonly LibraryContext _context;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public UserType UserType { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public int MaxBorrowDays()
        {
            switch (UserType)
            {
                case UserType.Regular:
                    return 30;
                case UserType.Special:
                    return 35;
                case UserType.Golden:
                    return 40;
                default:
                    return 30;
            }
        }

        public void ShowUserInfo(int userId)
        {
            var user = _context.Users.Include(u => u.BorrowedBooks).FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                Console.WriteLine($"Потребител: {user.FirstName} {user.MiddleName} {user.LastName}");
                Console.WriteLine($"Тип: {user.UserType}");
                Console.Write("Взети книги: ");

                foreach (var book in user.BorrowedBooks)
                {
                    Console.Write($" - {book.Title}, {book.Author}");
                }
                Console.WriteLine();
            }
        }
    }
}
