using System;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExamples.DependencyInjection.Logging
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli
    // cd .\AspNetCoreExamples.DependencyInjection.Logging (do not need to set Default project)
    // dotnet tool install --global dotnet-ef
    // dotnet add package Microsoft.EntityFrameworkCore.Design
    // dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    // dotnet ef migrations add CreateLogTable
    // dotnet ef database update
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=logging.db");
    }

    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
