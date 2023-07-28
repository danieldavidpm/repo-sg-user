using Entidades.Dto.OperacionesDto;

namespace Datos.Interfaces
{
    public interface IOperacionesD
    {
        Task<OperacionesAddDto> AddAsync(OperacionesAddDto dto);
        Task<string> UpdateAsync(OperacionesAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<OperacionesGetAllDto>> GetAll();
        Task<OperacionesGetAllDto?> GetById(int id);
    }
}
