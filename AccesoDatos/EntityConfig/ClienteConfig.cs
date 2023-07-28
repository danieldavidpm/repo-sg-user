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
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

            SendData(builder);
        }
        public void SendData(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasData(
            new Cliente { Id = 1, Nombre = "Solumaxt Eirl." },
            new Cliente { Id = 2, Nombre = "SG Hidrocarburos" }
            );
        }
    }
}
