using Entidades.Core;

namespace Entidades
{
    public class Modulo : Entity<int>
    {
        public string? Nombre { get; set; }
        public ICollection<Operaciones>? Operaciones { get; set; }
    }
}
