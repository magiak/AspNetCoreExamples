using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreExamples.DependencyInjection.Logging.v1
{
    public class DatabaseLogger
    {
        public void Log(string message, ApplicationDbContext dbContext)
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
