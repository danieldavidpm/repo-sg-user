using Entidades.Core;

namespace Entidades
{
    public class RolOpe : Entity<int>
    {
        public int IdRol { get; set; }
        public Rol? rol { get; set; }
        public int IdOpe { get; set; }
        public Operaciones? operaciones { get; set; }
    }
}
