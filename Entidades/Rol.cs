using Entidades.Core;

namespace Entidades
{
    public class Rol : Entity<int>
    {
        public string? Nombre { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }
        public virtual ICollection<RolOpe>? RolOpes { get; set; }
    }
}
