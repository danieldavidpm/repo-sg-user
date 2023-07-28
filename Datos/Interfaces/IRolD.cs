using Entidades.Dto.RolDto;

namespace Datos.Interfaces
{
    public interface IRolD
    {
        Task<RolAddDto> AddAsync(RolAddDto dto);
        Task<string> UpdateAsync(RolAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<RolGetAllDto>> GetAll();
        Task<RolGetAllDto?> GetById(int id);
    }
}
