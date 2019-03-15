﻿// <auto-generated />
using BeadsInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeadsInventory.Migrations.Finding
{
    [DbContext(typeof(FindingContext))]
    partial class FindingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("BeadsInventory.Models.Finding", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("Color");

                    b.Property<string>("Description");

                    b.Property<string>("FindingCategory");

                    b.Property<double>("Length_CM");

                    b.Property<string>("Material");

                    b.Property<double>("Price_Point");

                    b.HasKey("ID");

                    b.ToTable("Finding");
                });
#pragma warning restore 612, 618
        }
    }
}
