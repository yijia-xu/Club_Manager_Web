﻿// <auto-generated />
using System;
using Lab5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab5.Migrations
{
    [DbContext(typeof(SportsDbContext))]
    [Migration("20240804142103_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab5.Models.Fan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Fan", (string)null);
                });

            modelBuilder.Entity("Lab5.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SportClubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsId");

                    b.HasIndex("SportClubId");

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("Lab5.Models.SportClub", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SportsClub", (string)null);
                });

            modelBuilder.Entity("Lab5.Models.Subscription", b =>
                {
                    b.Property<int>("FanId")
                        .HasColumnType("int");

                    b.Property<string>("SportClubId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FanId", "SportClubId");

                    b.HasIndex("SportClubId");

                    b.ToTable("Subscription", (string)null);
                });

            modelBuilder.Entity("Lab5.Models.News", b =>
                {
                    b.HasOne("Lab5.Models.SportClub", "SportClub")
                        .WithMany("News")
                        .HasForeignKey("SportClubId");

                    b.Navigation("SportClub");
                });

            modelBuilder.Entity("Lab5.Models.Subscription", b =>
                {
                    b.HasOne("Lab5.Models.Fan", "Fans")
                        .WithMany("Subscriptions")
                        .HasForeignKey("FanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.SportClub", "SportClubs")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SportClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fans");

                    b.Navigation("SportClubs");
                });

            modelBuilder.Entity("Lab5.Models.Fan", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Lab5.Models.SportClub", b =>
                {
                    b.Navigation("News");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
