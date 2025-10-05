using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Director Director { get; set; }

        public int Duration { get; set; }

        public int ReleaseDate { get; set; }

        public double Rating { get; set; }
    }
}
