﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SafeCity.Server.Db.Context;

namespace SafeCity.Server.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Model.Appeal", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<long>("AppealTypeId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("bytea");

                    b.Property<string>("AttachmentPath")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<long>("SubtypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("AppealTypeId");

                    b.HasIndex("SubtypeId");

                    b.ToTable("Appeal");
                });

            modelBuilder.Entity("Model.AppealSubtype", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<long>("TypesId")
                        .HasColumnType("bigint");

                    b.HasKey("Key");

                    b.HasIndex("TypesId");

                    b.ToTable("SubtypeAppeals");

                    b.HasData(
                        new
                        {
                            Key = 1L,
                            Name = "Качество автомобильных дорог",
                            TypesId = 1L
                        },
                        new
                        {
                            Key = 2L,
                            Name = "Наличие/качество пешеходных переходов",
                            TypesId = 1L
                        },
                        new
                        {
                            Key = 3L,
                            Name = "Наличие/качество освещения",
                            TypesId = 1L
                        },
                        new
                        {
                            Key = 4L,
                            Name = "Безопасная дорога в школу для детей",
                            TypesId = 1L
                        },
                        new
                        {
                            Key = 5L,
                            Name = "Отсутствие/качество тротуаров",
                            TypesId = 2L
                        },
                        new
                        {
                            Key = 6L,
                            Name = "Отсутствие /качество ливневой канализации",
                            TypesId = 2L
                        },
                        new
                        {
                            Key = 7L,
                            Name = "Заброшенные объекты строительства / здания",
                            TypesId = 2L
                        },
                        new
                        {
                            Key = 8L,
                            Name = "Отсутствие /качество детских площадок",
                            TypesId = 2L
                        },
                        new
                        {
                            Key = 9L,
                            Name = "Проблемы при проведении капитального ремонта",
                            TypesId = 2L
                        },
                        new
                        {
                            Key = 10L,
                            Name = "Стихийные свалки",
                            TypesId = 2L
                        },
                        new
                        {
                            Key = 11L,
                            Name = "Отсутствие /качество инфраструктуры для передвижения людей с ограниченными возможностями",
                            TypesId = 2L
                        });
                });

            modelBuilder.Entity("Model.AppealType", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("TypeAppeal");

                    b.HasData(
                        new
                        {
                            Key = 1L,
                            Name = "Безопасность на дорогах"
                        },
                        new
                        {
                            Key = 2L,
                            Name = "Комфортное проживание"
                        });
                });

            modelBuilder.Entity("Model.Appeal", b =>
                {
                    b.HasOne("Model.AppealType", "AppealType")
                        .WithMany()
                        .HasForeignKey("AppealTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.AppealSubtype", "AppealSubtype")
                        .WithMany()
                        .HasForeignKey("SubtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppealSubtype");

                    b.Navigation("AppealType");
                });

            modelBuilder.Entity("Model.AppealSubtype", b =>
                {
                    b.HasOne("Model.AppealType", "AppealType")
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppealType");
                });
#pragma warning restore 612, 618
        }
    }
}
