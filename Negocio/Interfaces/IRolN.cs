using Entidades.Dto.RolDto;

namespace Negocio.Interfaces
{
    public interface IRolN
    {
        Task<RolAddDto> AddAsync(RolAddDto dto);
        Task<string> UpdateAsync(RolAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<RolGetAllDto>> GetAll();
        Task<RolGetAllDto?> GetById(int id);
    }
}
