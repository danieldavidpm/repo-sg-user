using Entidades;
using Entidades.Dto.RolDto;

namespace Datos.Mappers
{
    public class RolMapper
    {
        public Rol MapToAdd(RolAddDto dto)
        {
            return new Rol()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public RolAddDto MapToAdd(Rol dto)
        {
            return new RolAddDto()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

    }
}
