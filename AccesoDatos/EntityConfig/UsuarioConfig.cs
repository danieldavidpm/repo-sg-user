﻿using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(200);
            builder.HasIndex(e => e.Email) //para q no se repita el Email
            .IsUnique();

            builder.Property(e => e.Password)
            .HasMaxLength(200);

            builder.Property(e => e.ImagenPerfil)
            .HasMaxLength(200);

            builder.HasOne(x => x.rol)
            .WithMany(e => e.Usuarios)
            .HasForeignKey(e => e.IdRol)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.cliente)
            .WithMany(e => e.Usuarios)
            .HasForeignKey(e => e.IdCliente)
            .OnDelete(DeleteBehavior.Restrict);

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
            new Usuario { Id = 1, Nombre = "Daniel Perez", Email = "dani@gmail.com", Password = "123456", FechaVencimiento = DateTime.Now, IdRol = 1, IdCliente = 1 },
            new Usuario { Id = 2, Nombre = "Jhon Chonta", Email = "jhon@gmail.com", Password = "123456", FechaVencimiento = DateTime.Now, IdRol = 1, IdCliente = 1 },
            new Usuario { Id = 3, Nombre = "Marco Tarmeño", Email = "marco@gmail.com", Password = "123456", FechaVencimiento = DateTime.Now, IdRol = 3, IdCliente = 2 },
            new Usuario { Id = 4, Nombre = "Abigail Garcia", Email = "abi@gmail.com", Password = "123456", FechaVencimiento = DateTime.Now, IdRol = 4, IdCliente = 2 }
            );
        }
    }
}
