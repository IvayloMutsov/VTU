using TODO_Manager.Models;

namespace TODO_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Database.EnsureCreated();
                TaskManager taskManager = new TaskManager();
                UserManager manager = new UserManager();
                User user1 = new User("Ivan","Georgiev","GeorgievIvan@gmail.com","Yambol,General Zaimov,bl.5,ap.3");
                User user2 = new User("Stoyan","Iliev","S_Iliev@abv.bg");
                Models.Task task = new Models.Task("Get the server back on","Fix the bug that crashed the server and report it to the bosses.");
                manager.AddUser(user1);
                manager.AddUser(user2);
                taskManager.CreateTask(task);
                taskManager.AsignTask(task,new List<User> { user1, user2});
                taskManager.GetAllTasksForUser(user2);
                taskManager.GetAllTasksForUserByStatus(user1, Models.TaskStatus.Ongoing);
                db.SaveChanges();
            }
        }
    }
}
