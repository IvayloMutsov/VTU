using Infrastructure.BaseModels;
using System.ComponentModel;

namespace Infrastructure.Models
{
    public class Author: BasePerson
    {
        [DefaultValue(0)]
        public int TimesBookHasBeenLoaned { get; set; }
    }
}
