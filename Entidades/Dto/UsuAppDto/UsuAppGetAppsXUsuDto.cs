using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto.UsuAppDto
{
    public class UsuAppGetAppsXUsuDto
    {
        public int Id { get; set; }
        public int IdApp { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenApp { get; set; }
        public string? ContainerDeAdjuntos { get; set; }

    }
}
