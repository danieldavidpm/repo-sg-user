using Entidades.Core;

namespace Entidades
{
    public class Usuario : Entity<int>
    {
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImagenPerfil { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdRol { get; set; }
        public Rol? rol { get; set; }
        public ICollection<UsuApp>? UsuApps { get; set; }
        public int IdCliente { get; set; }
        public Cliente? cliente { get; set; }
    }
}
