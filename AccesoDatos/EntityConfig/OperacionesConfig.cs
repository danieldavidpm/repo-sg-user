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
    public class OperacionesConfig : IEntityTypeConfiguration<Operaciones>
    {
        public void Configure(EntityTypeBuilder<Operaciones> builder)
        {
            builder.ToTable("Operaciones");
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.modulo)
           .WithMany(e => e.Operaciones)
           .HasForeignKey(e => e.IdMod)
           .OnDelete(DeleteBehavior.Cascade);

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<Operaciones> builder)
        {
            builder.HasData(
            new Operaciones { Id = 1, Nombre = "Creación de usuarios", IdMod = 1 },
            new Operaciones { Id = 2, Nombre = "Actualización de usuarios", IdMod = 1 },
            new Operaciones { Id = 3, Nombre = "Consultar todas las ventas", IdMod = 2 },
            new Operaciones { Id = 4, Nombre = "Creación de contratos", IdMod = 2 }
            );
        }
    }
}
