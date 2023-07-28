using AccesoDatos.EntityConfig;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos
{
    public class DbContextConfig : DbContext
    {
        public DbContextConfig(DbContextOptions<DbContextConfig> options) : base(options)
        {
        }

        public DbSet<App> App { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuApp> UsuApp { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolOpe> RolOpe { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new UsuAppConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new RolOpeConfig());
            modelBuilder.ApplyConfiguration(new OperacionesConfig());
            modelBuilder.ApplyConfiguration(new ModuloConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
        }
    }
}
