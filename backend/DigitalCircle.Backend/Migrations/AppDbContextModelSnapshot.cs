﻿// <auto-generated />
using System;
using DigitalCircle.Backend.DigitalCircle.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitalCircle.Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("DigitalCircle.Backend.DigitalCircle.Domain.Entities.TB01", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("ColDt")
                        .HasColumnType("TEXT")
                        .HasColumnName("col_dt");

                    b.Property<string>("ColText")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("col_texto");

                    b.HasKey("Id");

                    b.ToTable("TB01");
                });
#pragma warning restore 612, 618
        }
    }
}
