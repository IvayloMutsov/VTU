using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public bool IsAvailable { get; set; }
        public int TimesBorrowed { get; set; }
    }
}
