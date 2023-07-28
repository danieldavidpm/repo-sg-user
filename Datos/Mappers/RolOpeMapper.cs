using Entidades;
using Entidades.Dto.RolOpe;

namespace Datos.Mappers
{
    public class RolOpeMapper
    {
        public RolOpe MapToAdd(RolOpeAddDto dto)
        {
            return new RolOpe()
            {
                Id = dto.Id,
                IdRol = dto.IdRol,
                IdOpe = dto.IdOperaciones
            };
        }

        public RolOpeAddDto MapToAdd(RolOpe dto)
        {
            return new RolOpeAddDto()
            {
                Id = dto.Id,
                IdRol = dto.IdRol,
                IdOperaciones = dto.IdOpe
            };
        }
    }
}
