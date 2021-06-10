using System;
using System.Collections.Generic;
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppealType>().HasData( new List<AppealType>()
            {
                new AppealType()
                {
                    Key = 1,
                    Name = "Безопасность на дорогах"
                },
                new AppealType()
                {
                    Key = 2,
                    Name = "Комфортное проживание"
                }
            });

            modelBuilder.Entity<AppealSubtype>().HasData(new List<AppealSubtype>()
            {
                new AppealSubtype()
                {
                    Name = "Качество автомобильных дорог",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Name = "Наличие/качество пешеходных переходов",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Name = "Наличие/качество освещения",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Name = "Безопасная дорога в школу для детей",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Name = "Отсутствие/качество тротуаров",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Name = "Отсутствие /качество ливневой канализации",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Name = "Заброшенные объекты строительства / здания",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Name = "Отсутствие /качество детских площадок",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Name = "Проблемы при проведении капитального ремонта",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Name = "Стихийные свалки",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Name = "Отсутствие /качество инфраструктуры для передвижения людей с ограниченными возможностями",
                    TypesId = 2
                }
            });
        }

        public DbSet<Appeal> Appeal { get; set; }
        public DbSet<AppealSubtype> SubtypeAppeals { get; set; }
        public DbSet<AppealType> TypeAppeal { get; set; }
        public DbSet<GeoPoint> GeoPoint { get; set; }
    }
}