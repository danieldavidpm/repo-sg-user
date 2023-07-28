using Entidades.Dto.ClienteDto;

namespace Datos.Interfaces
{
    public interface IClienteD
    {
        Task<ClienteAddDto> AddAsync(ClienteAddDto dto);
        Task<string> UpdateAsync(ClienteAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<ClienteGetAllDto>> GetAll();
        Task<ClienteGetAllDto?> GetById(int id);
    }
}
