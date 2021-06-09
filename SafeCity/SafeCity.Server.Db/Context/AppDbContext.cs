﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace SafeCity.Server.Db.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        }

        public DbSet<Appeal> Appeal { get; set; }
        public DbSet<AppealSubtype> SubtypeAppeals { get; set; }
        public DbSet<AppealType> TypeAppeal { get; set; }
        public DbSet<GeoPoint> GeoPoint { get; set; }
    }
}