﻿// <auto-generated />
using BeadsInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeadsInventory.Migrations.StringingMaterial
{
    [DbContext(typeof(StringingMaterialContext))]
    partial class StringingMaterialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("BeadsInventory.Models.StringingMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("Category");

                    b.Property<string>("Color");

                    b.Property<string>("Description");

                    b.Property<string>("Material");

                    b.Property<double>("Price_Per_Foot");

                    b.HasKey("ID");

                    b.ToTable("StringingMaterial");
                });
#pragma warning restore 612, 618
        }
    }
}