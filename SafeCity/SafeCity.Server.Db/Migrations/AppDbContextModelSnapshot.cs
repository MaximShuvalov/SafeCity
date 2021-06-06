﻿// <auto-generated />
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

                    b.Property<string>("Attachment")
                        .HasColumnType("text");

                    b.Property<long>("ClassAppealId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<long>("SubtypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("ClassAppealId");

                    b.HasIndex("SubtypeId");

                    b.ToTable("Appeal");
                });

            modelBuilder.Entity("Model.Class", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("Class");
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

                    b.ToTable("AppealType");
                });

            modelBuilder.Entity("Model.Appeal", b =>
                {
                    b.HasOne("Model.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassAppealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.AppealSubtype", "AppealSubtype")
                        .WithMany()
                        .HasForeignKey("SubtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("AppealSubtype");
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