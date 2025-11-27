using Infrastructure.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Publisher : BaseEntity
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public int YearFounded { get; set; }
    }
}
