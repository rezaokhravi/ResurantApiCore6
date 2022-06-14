﻿// <auto-generated />
using Core6.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core6.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220614184308_foreignKey")]
    partial class foreignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core6.Models.Entites.Foods", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("DESCRIPTIONS")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnOrder(4);

                    b.Property<long>("RES_ID")
                        .HasColumnType("bigint")
                        .HasColumnOrder(2);

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnOrder(3);

                    b.HasKey("ID");

                    b.HasIndex("RES_ID");

                    b.ToTable("FOODS");
                });

            modelBuilder.Entity("Core6.Models.Entites.Resturants", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnOrder(5);

                    b.Property<string>("DESCRIPTIONS")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnOrder(6);

                    b.Property<string>("MOBILE")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnOrder(4);

                    b.Property<string>("PHONE")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnOrder(3);

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnOrder(2);

                    b.HasKey("ID");

                    b.ToTable("RESTURANTS");
                });

            modelBuilder.Entity("Core6.Models.Entites.Foods", b =>
                {
                    b.HasOne("Core6.Models.Entites.Resturants", "Resturant")
                        .WithMany("Foods")
                        .HasForeignKey("RES_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resturant");
                });

            modelBuilder.Entity("Core6.Models.Entites.Resturants", b =>
                {
                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}