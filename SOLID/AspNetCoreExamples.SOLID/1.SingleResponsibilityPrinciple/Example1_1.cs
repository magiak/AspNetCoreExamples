using System;
using System.IO;

namespace AspNetCoreExamples.SOLID.SingleResponsibilityPrinciple
{
    public class Example1_1
    {
        public static void MainExample()
        {
            // Dependency injection :D
            var db = new Database();
            var logger = new Logger(db);
            var validator = new MovieValidator();
            var movieService = new MovieService(db, validator, logger);

            // Application / business logic
            movieService.CreateMovie("Episode IV – A New Hope (1977)");
            movieService.CreateMovie("Episode IX – The Rise of Skywalker (2019)");

            movieService.DeleteMovie("Pelíšky (1999)");
        }

        public class MovieService
        {
            private readonly Database _db;
            private readonly MovieValidator _validator;
            private readonly Logger _logger;

            public MovieService(Database db, MovieValidator validator, Logger logger)
            {
                _db = db;
                _validator = validator;
                _logger = logger;
            }

            public bool CreateMovie(string movie)
            {
                try
                {
                    if (!_validator.IsValidName(movie))
                    {
                        return false;
                    }

                    _db.Movies.Add(movie);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Log(ex);
                    return false;
                }
            }

            public bool DeleteMovie(string movie)
            {
                try
                {
                    _db.Movies.Remove(movie);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Log(ex);
                    return false;
                }
            }
        }

        public class Logger
        {
            private readonly Database _db;

            public Logger(Database db)
            {
                _db = db;
            }

            public void Log(Exception ex)
            {
                _db.Logs.Add($"Error: {ex.Message}");
                File.WriteAllText($"log{DateTime.Today.ToShortDateString()}.txt", $"{DateTime.Now}: {ex.Message}");
            }
        }

        public class MovieValidator
        {
            public bool IsValidName(string name)
            {
                if (name.Contains("sex", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                //if (validation)
                //{
                //    return false;
                //}

                return true;
            }
        }
    }
}
