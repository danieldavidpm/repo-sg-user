using Entidades.Dto.UsuAppDto;

namespace Datos.Interfaces
{
    public interface IUsuAppD
    {
        Task<UsuAppAddDto> AddAsync(UsuAppAddDto dto);
        Task<string> UpdateAsync(UsuAppAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<UsuAppGetAllDto>> GetAll();
        Task<UsuAppGetAllDto?> GetById(int id);
        Task<List<UsuAppGetAppsXUsuDto?>> GetAppsByIdUse(int id);
    }
}
