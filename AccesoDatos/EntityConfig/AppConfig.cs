using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccesoDatos.EntityConfig
{
    public class AppConfig : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.ToTable("App");
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nombre)
            .HasMaxLength(100);
            builder.HasIndex(e => e.Nombre) //para q no se repita el Nombre
            .IsUnique();

            builder.Property(e => e.ImagenApp)
            .HasMaxLength(200);

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<App> builder)
        {
            builder.HasData(
            new App { Id = 1, Nombre = "App Users Management", Descripcion = "Administración de usuarios", ImagenApp = "000_app_admin_user.jpg", ContainerDeAdjuntos = "f000solu01" },
            new App { Id = 2, Nombre = "SAIGNa Local", Descripcion = "Sistema de red local.", ImagenApp = "000_app_SAIGNa_Local_Icono.ico", ContainerDeAdjuntos = "f000solu01" },
            new App { Id = 3, Nombre = "SAIGNa Web - Solu", Descripcion = "Sistema web para instalaciones de gas.", ImagenApp = "000_app_logoTmp_Solumas.png", ContainerDeAdjuntos = "f000solu01" },
            new App { Id = 4, Nombre = "SAIGNa Web - Hidrocarburos", Descripcion = "Sistema web para instalaciones de gas", ImagenApp = "000_app_logoTmp_Solumas.png", ContainerDeAdjuntos = "f001sghi01" }
            );
        }
    }
}
