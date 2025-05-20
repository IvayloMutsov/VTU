using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDB
{
    public class MovieMap : ClassMap<CsvManager>
    {
        public MovieMap()
        {
            Map(x => x.Name).Name("Movie Name").Default("NO DATA");
            Map(x => x.ReleaseYear).Name("Release Year").Default("NO DATA");
            Map(x => x.Duration).Name("Duration").Default(0);
            Map(x => x.Rating).Name("IMDB Rating").Default(0);
            Map(x => x.Metascore).Name("Metascore").Default(0);
            Map(x => x.Votes).Name("Votes").Default("NO DATA");
            Map(x => x.Genre).Name("Genre").Default("NO DATA");
            Map(x => x.Director).Name("Director").Default("NO DATA");
            Map(x => x.Cast).Name("Cast").Default("NO DATA");
            Map(x => x.Gross).Name("Gross").Default("NO DATA");
        }
    }
}
