using Entidades.Dto.ModuloDto;

namespace Datos.Interfaces
{
    public interface IModuloD
    {
        Task<ModuloAddDto> AddAsync(ModuloAddDto dto);
        Task<string> UpdateAsync(ModuloAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<ModuloGetAllDto>> GetAll();
        Task<ModuloGetAllDto?> GetById(int id);
    }
}
