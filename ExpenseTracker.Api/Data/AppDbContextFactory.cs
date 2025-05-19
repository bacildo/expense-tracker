using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ExpenseTracker.Api.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1) lê appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // 2) pega connection string
            var conn = config.GetConnectionString("DefaultConnection");

            // 3) configura OptionsBuilder
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(conn);

            return new AppDbContext(builder.Options);
        }
    }
}
