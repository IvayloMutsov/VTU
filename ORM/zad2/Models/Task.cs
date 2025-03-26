using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Manager.Models
{
    public enum TaskStatus
    {
        New, Ongoing, Finnished
    }

    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        [Required,MaxLength(100)]
        public string Heading { get; set; }
        [Required,MaxLength(1000)]
        public string Description { get; set; }
        public List<User> TargetedUsers { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime? dateChanged { get; set; }
        public DateTime? dateFinnished { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string heading, string description)
        {
            Heading = heading;
            Description = description;
            TargetedUsers = new List<User>();
        }
    }
}
