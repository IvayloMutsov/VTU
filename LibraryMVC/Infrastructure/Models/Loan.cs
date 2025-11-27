using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Loan
    {
        [Required, Key]
        public int ID { get; set; }

        [Required]
        public Guid User { get; set; }

        [Required]
        public Book Book { get; set; }

        public DateOnly DateLoaned { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public int LoanPeriodDays { get; set; }

        public DateOnly ReturnDate { get; set; }

        [DefaultValue(false)]
        public bool isReturned { get; set; }
        
        [DefaultValue(false)]
        public bool isCancelled { get; set; }
        
        [DefaultValue(false)]
        public bool isExtended { get; set; }
    }
}
