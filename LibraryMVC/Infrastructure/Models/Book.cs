using System.ComponentModel.DataAnnotations;

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
