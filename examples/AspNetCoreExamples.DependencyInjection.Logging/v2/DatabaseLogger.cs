using System;

namespace AspNetCoreExamples.DependencyInjection.Logging.v2
{
    public class DatabaseLogger
    {
        private readonly ApplicationDbContext dbContext;

        public DatabaseLogger(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Log(string message)
        {
            dbContext.Logs.Add(new Log
            {
                Message = message,
                CreatedDate = DateTime.Now
            });
            dbContext.SaveChanges();
        }
    }
}
