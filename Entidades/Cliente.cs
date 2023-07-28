using Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Entity<int>
    {
        public string? Nombre { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }

    }
}
