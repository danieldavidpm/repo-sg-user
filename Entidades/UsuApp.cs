using Entidades.Core;

namespace Entidades
{
    public class UsuApp : Entity<int>
    {
        public int IdUsu { get; set; }
        public Usuario? usuario { get; set; }
        public int IdApp { get; set; }
        public App? app { get; set; }
    }
}
