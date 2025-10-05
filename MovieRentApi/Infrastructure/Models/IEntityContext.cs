using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public interface IEntityContext
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
