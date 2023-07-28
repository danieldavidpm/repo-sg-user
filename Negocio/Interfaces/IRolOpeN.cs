using Entidades.Dto.RolOpe;

namespace Negocio.Interfaces
{
    public interface IRolOpeN
    {
        Task<RolOpeAddDto> AddAsync(RolOpeAddDto dto);
        Task<string> UpdateAsync(RolOpeAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<RolOpeGetAllDto>> GetAll();
        Task<RolOpeGetAllDto?> GetById(int id);
    }
}
