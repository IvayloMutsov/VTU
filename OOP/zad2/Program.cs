namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            using (var context = new LibraryContext())
            {
                context.Database.EnsureCreated();
                var libraryService = new LibraryService(context);

                // Пример за добавяне на книги
                libraryService.AddBook("Book 5", "Author 1", 2020, new List<string> { "Fiction", "Drama" });
                libraryService.AddBook("Book 6", "Author 2", 2021, new List<string> { "Horror" });

                // Пример за създаване на потребители
                var user = new User
                {
                    FirstName = "Калина",
                    MiddleName = "Марчева",
                    LastName = "Петрова",
                    UserType = UserType.Regular
                };
                context.Users.Add(user);
                context.SaveChanges();

                // Пример за заемане на книга
                libraryService.BorrowBook(user.Id, 5);
                libraryService.BorrowBook(user.Id, 6);
                // Пример за показване на информация за потребителя
                user.ShowUserInfo(user.Id);
                Console.WriteLine(libraryService.GetBookBorrowCount(1));
                // Пример за връщане на книга
                Console.WriteLine("===============");
                libraryService.ReturnBook(user.Id, 6);
                libraryService.BorrowBook(user.Id, 6);
                Console.WriteLine(libraryService.GetBookBorrowCount(2));
            }
        }
    }
}
