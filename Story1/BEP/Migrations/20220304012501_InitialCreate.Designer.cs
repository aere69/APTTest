﻿// <auto-generated />
using BEP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BEP.Migrations
{
    [DbContext(typeof(CSVContext))]
    [Migration("20220304012501_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("BEP.CSVRecord", b =>
                {
                    b.Property<int>("CSVRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .HasColumnType("TEXT");

                    b.Property<int>("SortCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("CSVRecordId");

                    b.ToTable("CSVRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
