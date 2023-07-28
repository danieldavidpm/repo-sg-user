using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.EntityConfig
{
    public class RolConfig : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

            SendData(builder);
        }
        public void SendData(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
            new Rol { Id = 1, Nombre = "Soporte"},
            new Rol { Id = 2, Nombre = "Administrador" },
            new Rol { Id = 3, Nombre = "Vendedor" },
            new Rol { Id = 4, Nombre = "Coordinado de ventas" }
            );
        }
    }
}
