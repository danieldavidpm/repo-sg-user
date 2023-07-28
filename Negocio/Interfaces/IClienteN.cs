using Entidades.Dto.ClienteDto;

namespace Negocio.Interfaces
{
    public interface IClienteN
    {
        Task<ClienteAddDto> AddAsync(ClienteAddDto dto);
        Task<string> UpdateAsync(ClienteAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<ClienteGetAllDto>> GetAll();
        Task<ClienteGetAllDto?> GetById(int id);
    }
}
