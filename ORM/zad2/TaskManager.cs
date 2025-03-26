using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_Manager.Models;

namespace TODO_Manager
{
    class TaskManager
    {
        private List<Models.Task> Tasks { get; set; }

        public TaskManager()
        {
            Tasks = new List<Models.Task>();
        }

        public void CreateTask(Models.Task t)
        {
            Tasks.Add(t);
            t.dateCreated = DateTime.Now;
            t.Status = Models.TaskStatus.New;
        }

        public void DeleteTask(Models.Task t)
        {
            Tasks.Remove(t);
            t.dateFinnished = DateTime.Now;
            t.Status = Models.TaskStatus.Finnished;
        }

        public void EditTask(Models.Task t)
        {
            t.Description = Console.ReadLine();
            t.dateChanged = DateTime.Now;
        }

        public void AsignTask(Models.Task t, List<User> u)
        {
            foreach (User item in u)
            {
                t.TargetedUsers.Add(item);
            }
            t.Status = Models.TaskStatus.Ongoing;
        }

        public void GetAllTasksForUser(User u)
        {
            List<Models.Task> tasks = new List<Models.Task>();
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].TargetedUsers.Contains(u))
                {
                    tasks.Add(Tasks[i]);
                }
            }
            Console.WriteLine(u.FirstName + " " + u.LastName);
            foreach (Models.Task item in tasks)
            {
                Console.WriteLine($"{item.Heading} - {item.Description} : {item.Status}");
            }
        }

        public void GetAllTasksForUserByStatus(User u, Models.TaskStatus s)
        {
            List<Models.Task> tasks = new List<Models.Task>();
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].TargetedUsers.Contains(u))
                {
                    tasks.Add(Tasks[i]);
                }
            }
            Console.WriteLine(u.FirstName + " " + u.LastName);
            var taskByStatus = tasks.Select(x => x.Status == s).ToList();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Status == s)
                {
                    Console.WriteLine($"{tasks[i].Heading} - {tasks[i].Description} : {tasks[i].Status}");
                }
            }
        }
    }
}
