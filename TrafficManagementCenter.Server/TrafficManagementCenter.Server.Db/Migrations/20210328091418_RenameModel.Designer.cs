﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TrafficManagementCenter.Server.Db.Context;

namespace TrafficManagementCenter.Server.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210328091418_RenameModel")]
    partial class RenameModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Model.AppealClass", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("ClassAppeal");
                });

            modelBuilder.Entity("Model.SubtypeAppeal", b =>
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

            modelBuilder.Entity("Model.TypeAppeal", b =>
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
                });

            modelBuilder.Entity("Model.Appeal", b =>
                {
                    b.HasOne("Model.AppealClass", "AppealClass")
                        .WithMany()
                        .HasForeignKey("ClassAppealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.SubtypeAppeal", "Subtype")
                        .WithMany()
                        .HasForeignKey("SubtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppealClass");

                    b.Navigation("Subtype");
                });

            modelBuilder.Entity("Model.SubtypeAppeal", b =>
                {
                    b.HasOne("Model.TypeAppeal", "Type")
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
