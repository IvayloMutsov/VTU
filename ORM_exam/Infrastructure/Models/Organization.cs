using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Organization
    {
        public int Index { get; set; }

        public string OrganizationId { get; set; }

        public string Name { get; set; }

        [Required]
        public Website Website { get; set; }

        [Required]
        public Country Country { get; set; }

        public string Description { get; set; }

        [MinLength(4),MaxLength(4)]
        public int Founded { get; set; }

        [Required]
        public Industry Industry { get; set; }

        public int Numberofemployees { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateModified { get; set; }
    }
}
