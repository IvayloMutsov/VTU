using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Manager.Models
{

    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [MinLength(3),MaxLength(30)]
        public string FirstName { get; set; }
        [MinLength(3),MaxLength(30)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Adress { get; set; }

        public User(string firstName, string lastName, string email, string adress)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adress = adress;
        }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
