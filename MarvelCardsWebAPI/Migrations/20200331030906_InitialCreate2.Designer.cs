﻿// <auto-generated />
using System;
using MarvelCardsWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarvelCardsWebAPI.Migrations
{
    [DbContext(typeof(MarvelCardsWebAPIContext))]
    [Migration("20200331030906_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XF_Prism_MarvelCards.Model.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DB_CRDAT")
                        .HasColumnType("datetime2");

                    b.Property<string>("DB_CRUSR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DB_TRDAT")
                        .HasColumnType("datetime2");

                    b.Property<string>("DB_TRUSR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroNameLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroNameLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hero","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DB_CRDAT = new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(2106),
                            DB_CRUSR = "David",
                            HeroColor = "#C51925",
                            HeroName = "spider man",
                            Image = "spiderman.png",
                            RealName = "peter parker"
                        },
                        new
                        {
                            Id = 2,
                            DB_CRDAT = new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(7176),
                            DB_CRUSR = "David",
                            HeroColor = "#DF8E04",
                            HeroName = "iron man",
                            Image = "ironman.png",
                            RealName = "tony stark"
                        },
                        new
                        {
                            Id = 3,
                            DB_CRDAT = new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(7230),
                            DB_CRUSR = "David",
                            HeroColor = "#5DDF04",
                            HeroName = "This is Test Data",
                            Image = "ironman.png",
                            RealName = "tony stark"
                        },
                        new
                        {
                            Id = 4,
                            DB_CRDAT = new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(7233),
                            DB_CRUSR = "David",
                            HeroColor = "#040DDF",
                            HeroName = "This is Test Data2",
                            Image = "ironman.png",
                            RealName = "tony stark"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
