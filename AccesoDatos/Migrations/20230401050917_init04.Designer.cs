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
    [Migration("20230401050917_init04")]
    partial class init04
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

            modelBuilder.Entity("Entidades.Modulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modulo", (string)null);
                });

            modelBuilder.Entity("Entidades.Operaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdMod")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdMod");

                    b.ToTable("Operaciones", (string)null);
                });

            modelBuilder.Entity("Entidades.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Entidades.RolOpe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdOpe")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOpe");

                    b.HasIndex("IdRol");

                    b.ToTable("RolOpe", (string)null);
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

                    b.HasKey("Id");

                    b.HasIndex("IdApp");

                    b.HasIndex("IdUsu");

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

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Entidades.Operaciones", b =>
                {
                    b.HasOne("Entidades.Modulo", "modulo")
                        .WithMany("Operaciones")
                        .HasForeignKey("IdMod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("modulo");
                });

            modelBuilder.Entity("Entidades.RolOpe", b =>
                {
                    b.HasOne("Entidades.Operaciones", "operaciones")
                        .WithMany("RolOpes")
                        .HasForeignKey("IdOpe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Rol", "rol")
                        .WithMany("RolOpes")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("operaciones");

                    b.Navigation("rol");
                });

            modelBuilder.Entity("Entidades.UsuApp", b =>
                {
                    b.HasOne("Entidades.App", "app")
                        .WithMany("UsuApps")
                        .HasForeignKey("IdApp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Usuario", "usuario")
                        .WithMany("UsuApps")
                        .HasForeignKey("IdUsu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("app");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.HasOne("Entidades.Rol", "rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rol");
                });

            modelBuilder.Entity("Entidades.App", b =>
                {
                    b.Navigation("UsuApps");
                });

            modelBuilder.Entity("Entidades.Modulo", b =>
                {
                    b.Navigation("Operaciones");
                });

            modelBuilder.Entity("Entidades.Operaciones", b =>
                {
                    b.Navigation("RolOpes");
                });

            modelBuilder.Entity("Entidades.Rol", b =>
                {
                    b.Navigation("RolOpes");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.Navigation("UsuApps");
                });
#pragma warning restore 612, 618
        }
    }
}