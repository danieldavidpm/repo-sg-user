using Entidades.Core;

namespace Entidades
{
    public class Operaciones : Entity<int>
    {
        public string? Nombre { get; set; }
        public int IdMod { get; set; }
        public Modulo? modulo { get; set; }
        public ICollection<RolOpe>? RolOpes { get; set; }
    }
}
