using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Book: BaseEntity
    {
        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Author Author { get; set; }
    }
}
