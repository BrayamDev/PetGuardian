﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetGuardianAPI;

#nullable disable

namespace PetGuardianAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240421003833_Fundaciones")]
    partial class Fundaciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PetGuardianAPI.Entidades.adoptantes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("direccionResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreAdoptante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numeroContacto")
                        .HasColumnType("int");

                    b.Property<int>("numeroDocumento")
                        .HasColumnType("int");

                    b.Property<int>("numeroEmergencia")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("adoptantes");
                });

            modelBuilder.Entity("PetGuardianAPI.Entidades.fundaciones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreFundacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("fundaciones");
                });

            modelBuilder.Entity("PetGuardianAPI.Entidades.tipoAnimal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreTipoAnimal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tipoAnimal");
                });

            modelBuilder.Entity("PetGuardianAPI.Entidades.vacunas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("fechaCaducidad")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreVacuna")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("id");

                    b.ToTable("vacunas");
                });
#pragma warning restore 612, 618
        }
    }
}
