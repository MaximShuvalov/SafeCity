using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace TrafficManagementCenter.Server.Db.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            optionsBuilder.UseNpgsql(config.GetConnectionString("ConnectionDb"));
        }

        public DbSet<Appeal> Appeal { get; set; }
        public DbSet<SubtypeAppeal> SubtypeAppeals { get; set; }
        public DbSet<TypeAppeal> TypeAppeal { get; set; }
        public DbSet<AppealClass> ClassAppeal { get; set; }
    }
}