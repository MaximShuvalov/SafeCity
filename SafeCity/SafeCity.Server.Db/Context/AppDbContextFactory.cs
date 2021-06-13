using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SafeCity.Server.Db.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            //builder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            builder.UseNpgsql(config.GetConnectionString("ConnectionDb"));
            return new AppDbContext(builder.Options);
        }
    }
}