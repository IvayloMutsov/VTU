using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDB.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; }
    }
}
