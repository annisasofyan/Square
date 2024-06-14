﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Db_context))]
    partial class Db_contextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("API.Models.Square", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Squares");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.Weather", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("humidity")
                        .HasColumnType("int");

                    b.Property<int>("temperature")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<int>("windSpeed")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("API.Models.WetherDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<int>("weatherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cityId");

                    b.HasIndex("weatherId");

                    b.ToTable("WetherDetails");
                });

            modelBuilder.Entity("API.Models.WetherDetails", b =>
                {
                    b.HasOne("API.Models.City", "City")
                        .WithMany("WeatherDetails")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Weather", "Weather")
                        .WithMany("WeatherDetails")
                        .HasForeignKey("weatherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("API.Models.City", b =>
                {
                    b.Navigation("WeatherDetails");
                });

            modelBuilder.Entity("API.Models.Weather", b =>
                {
                    b.Navigation("WeatherDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
