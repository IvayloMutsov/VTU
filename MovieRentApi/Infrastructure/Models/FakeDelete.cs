using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class FakeDelete : IEntityContext
    {
        [Required,Key]
        public int ID { get; set; }

        public int EntityID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
