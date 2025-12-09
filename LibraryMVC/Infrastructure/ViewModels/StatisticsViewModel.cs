using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class StatisticsViewModel
    {
        public List<Book> FavouriteBooks { get; set; }

        public List<Author> PopularAuthors { get; set; }

        public List<Loan> ActiveLoans { get; set; }
    }
}
