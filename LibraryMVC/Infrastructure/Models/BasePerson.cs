using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public abstract class BasePerson: BaseEntity, IPerson //base class for all people objects (authors,workers,etc.)
    {
        public int Age { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Nationality { get; set; }
    }
}
