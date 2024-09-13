﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingMall.Data;

#nullable disable

namespace ParkingMall.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240419191018_Bismillah")]
    partial class Bismillah
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParkingMall.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ParkingMall.Models.DetailParkir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("BiayaParkir")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BiayaPerJam")
                        .HasColumnType("int");

                    b.Property<int>("ParkirId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ParkirId");

                    b.ToTable("DetailParking");
                });

            modelBuilder.Entity("ParkingMall.Models.Parkir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PlateNomor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeTransportasiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WaktuMasuk")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TypeTransportasiId");

                    b.ToTable("Parkir");
                });

            modelBuilder.Entity("ParkingMall.Models.TypeTransportasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BiayaPerJam")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TransportationTypes");
                });

            modelBuilder.Entity("ParkingMall.Models.DetailParkir", b =>
                {
                    b.HasOne("ParkingMall.Models.Parkir", "Parkir")
                        .WithMany()
                        .HasForeignKey("ParkirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parkir");
                });

            modelBuilder.Entity("ParkingMall.Models.Parkir", b =>
                {
                    b.HasOne("ParkingMall.Models.TypeTransportasi", "TypeTransportasi")
                        .WithMany()
                        .HasForeignKey("TypeTransportasiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeTransportasi");
                });
#pragma warning restore 612, 618
        }
    }
}
