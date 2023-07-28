using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccesoDatos.EntityConfig
{
    public class UsuAppConfig : IEntityTypeConfiguration<UsuApp>
    {
        public void Configure(EntityTypeBuilder<UsuApp> builder)
        {
            builder.ToTable("UsuApp");
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.usuario)
            .WithMany(e => e.UsuApps)
            .HasForeignKey(e => e.IdUsu)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.app)
            .WithMany(e => e.UsuApps)
            .HasForeignKey(e => e.IdApp)
            .OnDelete(DeleteBehavior.Cascade);

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<UsuApp> builder)
        {
            builder.HasData(
            new UsuApp { Id = 1, IdUsu = 3, IdApp = 2 },
            new UsuApp { Id = 2, IdUsu = 4, IdApp = 2 }
            );
        }
    }
}
