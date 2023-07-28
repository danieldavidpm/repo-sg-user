using Entidades;
using Entidades.Dto.ModuloDto;

namespace Datos.Mappers
{
    public class ModuloMapper
    {
        public Modulo MapToAdd(ModuloAddDto dto)
        {
            return new Modulo()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public ModuloAddDto MapToAdd(Modulo dto)
        {
            return new ModuloAddDto()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }
    }
}
