using Entidades.Core;

namespace Entidades
{
    public class App : Entity<int>
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenApp { get; set; }
        public string? ContainerDeAdjuntos { get; set; }        //a hoy Oct-2023 es en Azure. ejm f000solu01
        public ICollection<UsuApp>? UsuApps { get; set; }
    }
}