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

            SendData(builder);
        }

        public void SendData(EntityTypeBuilder<App> builder)
        {
            builder.HasData(
            new App { Id = 1, Nombre = "App Users Management" },
            new App { Id = 2, Nombre = "SAIGNa Web" }
            );
        }
    }
}
