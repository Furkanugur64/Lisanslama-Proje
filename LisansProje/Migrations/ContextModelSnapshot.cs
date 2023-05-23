﻿// <auto-generated />
using System;
using LisansProje.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LisansProje.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LisansProje.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("LisansProje.Models.Lisans", b =>
                {
                    b.Property<int>("LisansID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LisansID"));

                    b.Property<DateTime>("DegisiklikTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("Degistiren_K_Id")
                        .HasColumnType("int");

                    b.Property<byte>("Durum")
                        .HasColumnType("tinyint");

                    b.Property<int>("Kaydeden_K_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KurumAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KurumIpAdresi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LisansBaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("LisansKisiSayisi")
                        .HasColumnType("int");

                    b.Property<string>("LisansKodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SifreliId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ToplamYil")
                        .HasColumnType("int");

                    b.Property<string>("YazilimAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YazilimProtokolNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LisansID");

                    b.ToTable("Licences");
                });
#pragma warning restore 612, 618
        }
    }
}