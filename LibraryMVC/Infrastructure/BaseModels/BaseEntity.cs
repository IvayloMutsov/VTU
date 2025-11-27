using Infrastructure.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.BaseModels
{
    public abstract class BaseEntity: ILibraryEntity //base entity for all objects in the library
    {
        [Required, Key]
        public int ID { get; set; }

        [Required, MaxLength(50, ErrorMessage = "The name is too long")]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateLastModified { get; set; }

        public DateTime DateDeleted { get; set; }

        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
