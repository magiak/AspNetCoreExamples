using System;
using System.IO;

namespace AspNetCoreExamples.SOLID.SingleResponsibilityPrinciple
{
    public class Example1
    {
        public static void MainExample()
        {
            var db = new Database();
            var movieService = new MovieService();

            movieService.CreateMovie(db, "Episode IV – A New Hope (1977)");
            movieService.CreateMovie(db, "Episode IX – The Rise of Skywalker (2019)");

            movieService.DeleteMovie(db, "Pelíšky (1999)");
        }

        public class MovieService
        {
            public bool CreateMovie(Database db, string movie)
            {
                try
                {
                    if (movie.Contains("sex", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }

                    //if (validation)
                    //{
                    //    return false;
                    //}

                    db.Movies.Add(movie);
                    return true;
                }
                catch (Exception ex)
                {
                    db.Logs.Add($"Error: {ex.Message}");
                    File.WriteAllText($"log{DateTime.Today.ToShortDateString()}.txt", $"{DateTime.Now}: {ex.Message}");
                    return false;
                }
            }

            public bool DeleteMovie(Database db, string movie)
            {
                try
                {
                    db.Movies.Remove(movie);
                    return true;
                }
                catch (Exception ex)
                {
                    db.Logs.Add($"Error: {ex.Message}");
                    File.WriteAllText($"log{DateTime.Today.ToShortDateString()}.txt", $"{DateTime.Now}: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
