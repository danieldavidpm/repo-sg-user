using Entidades.Dto.AppDto;

namespace Datos.Interfaces
{
    public interface IAppD
    {
        Task<AppAddDto> AddAsync(AppAddDto dto);
        Task<string> UpdateAsync(AppAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<AppGetAllDto>> GetAll();
        Task<AppGetAllDto?> GetById(int id);
    }
}
