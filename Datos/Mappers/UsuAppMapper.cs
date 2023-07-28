using Entidades;
using Entidades.Dto.UsuAppDto;

namespace Datos.Mappers
{
    public class UsuAppMapper
    {
        public UsuApp MapToAdd(UsuAppAddDto dto)
        {
            return new UsuApp()
            {
                Id = dto.Id,
                IdUsu = dto.IdUsuario,
                IdApp = dto.IdApp,
            };
        }

        public UsuAppAddDto MapToAdd(UsuApp dto)
        {
            if (dto is null)
                return new UsuAppAddDto();

            return new UsuAppAddDto()
            {
                Id = dto.Id,
                IdUsuario = dto.IdUsu,
                IdApp = dto.IdApp,
            };
        }
    }
}
