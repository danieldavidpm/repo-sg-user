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
 
    public class ModuloConfig : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("Modulo");
            builder.HasKey(p => p.Id);

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<Modulo> builder)
        {
            builder.HasData(
            new Modulo { Id = 1, Nombre = "Administración del sistema" },
            new Modulo { Id = 2, Nombre = "Gestión comercial" },
            new Modulo { Id = 3, Nombre = "Construcción Internas" }
            );
        }
    }
}
