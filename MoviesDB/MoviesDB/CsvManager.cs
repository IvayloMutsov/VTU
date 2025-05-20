using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDB
{
    public class CsvManager
    {
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public double Metascore { get; set; }
        public string Votes { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Gross { get; set; }

        public int ParseGross(string gross)
        {
            gross = gross.Replace("$", "").Replace(",", "");
            return int.TryParse(gross, out var result) ? result : 0;
        }
    }
}
