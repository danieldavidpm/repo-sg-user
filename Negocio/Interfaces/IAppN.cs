using Entidades.Dto.AppDto;

namespace Negocio.Interfaces
{
    public interface IAppN
    {
        Task<AppAddDto> AddAsync(AppAddDto dto);
        Task<string> UpdateAsync(AppAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<AppGetAllDto>> GetAll();
        Task<AppGetAllDto?> GetById(int id);
    }
}
