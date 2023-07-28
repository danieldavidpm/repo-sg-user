using Entidades;
using Entidades.Dto.AppDto;

namespace Datos.Mappers
{
    public class AppMapper
    {
        public App MapToAdd(AppAddDto dto)
        {
            return new App()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public AppAddDto MapToAdd(App dto)
        {
            return new AppAddDto()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }
    }
}
