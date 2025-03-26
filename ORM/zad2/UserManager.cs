using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_Manager.Models;

namespace TODO_Manager
{
    class UserManager
    {
        public List<User> Users { get; set; }

        public UserManager()
        {
            Users = new List<User>();
        }

        public void AddUser(User u)
        {
            Users.Add(u);
        }

        public void DeleteUser(User u)
        {
            Users.Remove(u);
        }
    }
}
