﻿// <auto-generated />
using System;
using BookApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221031192854_InitialDb06")]
    partial class InitialDb06
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("BookApp.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReservBookId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReservBookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookApp.Models.ReservBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ReservBooks");
                });

            modelBuilder.Entity("BookApp.Models.Book", b =>
                {
                    b.HasOne("BookApp.Models.ReservBook", null)
                        .WithMany("Books")
                        .HasForeignKey("ReservBookId");
                });

            modelBuilder.Entity("BookApp.Models.ReservBook", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
