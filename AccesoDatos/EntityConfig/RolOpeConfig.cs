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
    public class RolOpeConfig : IEntityTypeConfiguration<RolOpe>
    {
        public void Configure(EntityTypeBuilder<RolOpe> builder)
        {
            builder.ToTable("RolOpe");
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.rol)
           .WithMany(e => e.RolOpes)
           .HasForeignKey(e => e.IdRol)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.operaciones)
            .WithMany(e => e.RolOpes)
            .HasForeignKey(e => e.IdOpe)
            .OnDelete(DeleteBehavior.Cascade);

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<RolOpe> builder)
        {
            builder.HasData(
                //el rol Soporte hace absolutamente todo.
            //new RolOpe { IdRol = 2, IdOpe = 1 }, el rol administrador no crea usuarios.
            new RolOpe { Id = 1, IdRol = 2, IdOpe = 2 }, //el rol administrador actualiza usuarios.
            new RolOpe { Id = 2, IdRol = 2, IdOpe = 3 }, //el rol administrador si puede consultar todas las ventas
            new RolOpe { Id = 3, IdRol = 2, IdOpe = 4 }, //el rol administrador puede crear contratos
            new RolOpe { Id = 4, IdRol = 3, IdOpe = 4 }, //el rol vendedor puede crear contratos
            new RolOpe { Id = 5, IdRol = 4, IdOpe = 3 }, //el rol coordinador si puede consultar todas las ventas
            new RolOpe { Id = 6, IdRol = 4, IdOpe = 4 }  //el rol coordinador puede crear contratos
            );
        }
    }
}
