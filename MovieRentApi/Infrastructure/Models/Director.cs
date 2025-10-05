using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Director : BaseEntity
    {
        public int Age { get; set; }

        public List<Movie> MoviesDirected { get; set; }
    }
}
