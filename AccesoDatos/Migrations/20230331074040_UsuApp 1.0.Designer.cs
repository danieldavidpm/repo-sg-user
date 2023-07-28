﻿// <auto-generated />
using System;
using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccesoDatos.Migrations
{
    [DbContext(typeof(DbContextConfig))]
    [Migration("20230331074040_UsuApp 1.0")]
    partial class UsuApp10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entidades.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("App", (string)null);
                });

            modelBuilder.Entity("Entidades.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Entidades.UsuApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdApp")
                        .HasColumnType("int");

                    b.Property<int>("IdUsu")
                        .HasColumnType("int");

                    b.Property<int?>("appId")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("appId");

                    b.HasIndex("usuarioId");

                    b.ToTable("UsuApp", (string)null);
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("ImagenPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("rolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("rolId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Entidades.UsuApp", b =>
                {
                    b.HasOne("Entidades.App", "app")
                        .WithMany()
                        .HasForeignKey("appId");

                    b.HasOne("Entidades.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("app");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.HasOne("Entidades.Rol", "rol")
                        .WithMany()
                        .HasForeignKey("rolId");

                    b.Navigation("rol");
                });
#pragma warning restore 612, 618
        }
    }
}
