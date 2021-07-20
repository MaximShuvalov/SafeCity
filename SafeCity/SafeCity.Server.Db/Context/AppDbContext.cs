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
            Database.Migrate();
        }

        public AppDbContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            //optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            optionsBuilder.UseNpgsql(config.GetConnectionString("ConnectionDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppealType>().HasData(new List<AppealType>()
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
                    Key = 1,
                    Name = "Качество автомобильных дорог",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Key = 2,
                    Name = "Отсутствие/качество пешеходных переходов",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Key = 3,
                    Name = "Отсутствие/качество освещения",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Key = 4,
                    Name = "Безопасная дорога в школу",
                    TypesId = 1
                },
                new AppealSubtype()
                {
                    Key = 5,
                    Name = "Ккачество тротуаров",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Key = 6,
                    Name = "Отсутствие /качество ливневой канализации",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Key = 7,
                    Name = "Заброшенные объекты строительства / здания",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Key = 8,
                    Name = "Отсутствие /качество детских площадок",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Key = 9,
                    Name = "Проблемы при проведении капитального ремонта",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Key = 10,
                    Name = "Стихийные свалки",
                    TypesId = 2
                },
                new AppealSubtype()
                {
                    Key = 11,
                    Name = "Отсутствие /качество инфраструктуры для передвижения людей с ограниченными возможностями",
                    TypesId = 2
                }
            });
        }

        public DbSet<Appeal> Appeal { get; set; }
        public DbSet<AppealSubtype> SubtypeAppeals { get; set; }
        public DbSet<AppealType> TypeAppeal { get; set; }
        //cpublic DbSet<GeoPoint> GeoPoint { get; set; }
    }
}