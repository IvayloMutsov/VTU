using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public abstract class BaseEntity : IEntityContext
    {
        [Required,Key]
        public int ID { get; set; }

        [DefaultValue(""),MaxLength(50)]
        public string Name { get; set; }

        [Required,DefaultValue(false)]
        public bool IsDeleted { get ; set; }
    }
}
