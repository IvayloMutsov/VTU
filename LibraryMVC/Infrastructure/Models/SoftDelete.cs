using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class SoftDelete
    {
        [Required,Key]
        public int ID { get; set; }

        [Required, MaxLength(50, ErrorMessage = "The name is too long")]
        public string Name { get; set; }

        public DateTime DateLastModified { get; set; }

        public DateTime DateDeleted { get; set; } = DateTime.Now;

        [Required, DefaultValue(true)]
        public bool IsDeleted { get; set; }
    }
}
