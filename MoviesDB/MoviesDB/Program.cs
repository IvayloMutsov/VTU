using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.SqlServer.Server;
using MoviesDB.Models;
using System.Globalization;

namespace MoviesDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Genre> genres = new List<Genre>();
            List<Director> directors = new List<Director>();
            List<Cast> actors = new List<Cast>();
            MoviesDBcontext context = new MoviesDBcontext();
            StreamReader reader = new StreamReader($"C:\\Users\\{Environment.UserName}\\Documents\\imdb_top_2000_movies.csv");
            CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            });
            CsvManager manager = new CsvManager();
            using (context)
            {
                context.Database.EnsureCreated();
                using (reader)
                {
                    using (csv)
                    {
                        int a = 1;
                        csv.Context.RegisterClassMap<MovieMap>();
                        var records = csv.GetRecords<CsvManager>().ToList();
                        foreach (var item in records)
                        {
                            var genre = new Genre { Type = item.Genre };
                            var director = new Director { Name = item.Director };
                            var cast = new Cast { Name = item.Cast };
                            genres.Add(genre);
                            directors.Add(director);
                            actors.Add(cast);

                            int gross = manager.ParseGross(item.Gross.ToString());

                            if (item.ReleaseYear.Contains('–'))
                            {
                                string tempYear = item.ReleaseYear.Substring(5);
                                item.ReleaseYear = tempYear;
                            }
                            if (item.ReleaseYear.Contains('I'))
                            {
                                string tempYear = item.ReleaseYear.Substring(2);
                                item.ReleaseYear = tempYear;
                            }
                            if (item.ReleaseYear.Contains('V'))
                            {
                                string tempYear = item.ReleaseYear.Substring(0,4);
                                item.ReleaseYear = tempYear;
                            }
                            if (item.ReleaseYear.Contains(' '))
                            {
                                string tempYear = item.ReleaseYear.Replace(" ", "");
                                item.ReleaseYear = tempYear;
                            }
                            Console.WriteLine(a + " " + item.Duration);
                            a++;
                            var movie = new Movie
                            {
                                Name = item.Name,
                                ReleaseYear = int.Parse(item.ReleaseYear),
                                Duration = item.Duration,
                                Rating = item.Rating,
                                Metascore = item.Metascore,
                                Votes = int.Parse(item.Votes.ToString().Replace(",", "").Replace('"','\0')),
                                Gross = gross,
                                Genre = genre,
                                Director = director,
                                Cast = cast
                            };

                            context.Movies.Add(movie);
                        }
                        var distinctDirectors = directors.DistinctBy(x => x.Name);
                        var distinctActors = actors.DistinctBy(x => x.Name);
                        List<Genre> tempGenres = new List<Genre>();
                        List<string> temp = new List<string>();
                        foreach (var item in genres)
                        {
                            string[] itemGenres = item.Type.Replace('"','\0').Replace(' ','\0').Split(',');
                            for (int i = 0; i < itemGenres.Length; i++)
                            {
                                temp.Add(itemGenres[i]);
                            }
                        }
                        foreach (var item in temp)
                        {
                            tempGenres.Add(new Genre { Type = item});
                        }
                        var distinctGenres = tempGenres.DistinctBy(x => x.Type);
                        foreach (var item in distinctActors)
                        {
                            context.Actors.Add(item);
                        }
                        foreach (var item in distinctDirectors)
                        {
                            context.Directors.Add(item);
                        }
                        foreach (var item in distinctGenres)
                        {
                            context.Genres.Add(item);
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
