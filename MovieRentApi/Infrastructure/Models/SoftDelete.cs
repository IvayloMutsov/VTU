using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class SoftDelete : IEntityContext
    {
        [Required,Key]
        public int ID { get; set; }

        public int EntityID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateDeleted => DateTime.Now;
    }
}
