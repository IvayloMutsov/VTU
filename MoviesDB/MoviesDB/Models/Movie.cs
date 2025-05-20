using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDB.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public int Duration { get; set; }

        public double Rating { get; set; }

        public double Metascore { get; set; }

        public int Votes { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Director Director { get; set; }

        [Required]
        public Cast Cast { get; set; }

        public int Gross { get; set; }
    }
}
