using Entidades;
using Entidades.Dto.OperacionesDto;

namespace Datos.Mappers
{
    public class OperacionesMapper
    {
        public Operaciones MapToAdd(OperacionesAddDto dto)
        {
            return new Operaciones()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                IdMod = dto.IdModulo
            };
        }

        public OperacionesAddDto MapToAdd(Operaciones dto)
        {
            return new OperacionesAddDto()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                IdModulo = dto.IdMod
            };
        }
    }
}
