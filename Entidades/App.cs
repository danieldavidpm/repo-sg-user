using Entidades.Core;

namespace Entidades
{
    public class App : Entity<int>
    {
        public string? Nombre { get; set; }
        public ICollection<UsuApp>? UsuApps { get; set; }
    }
}