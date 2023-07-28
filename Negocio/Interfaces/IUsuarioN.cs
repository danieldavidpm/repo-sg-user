using Common;
using Entidades.Dto.UsuarioDto;

namespace Negocio.Interfaces
{
    public interface IUsuarioN
    {
        Task<JsonResult<UsuarioAddDto>> AddAsync(UsuarioAddDto dto);
        Task<JsonResult<UsuarioAddDto>> UpdateAsync(UsuarioAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<UsuarioGetAllDto>> GetAll();
        Task<UsuarioGetAllDto?> GetById(int id);
        Task<AuthenticateDto?> GetAuthenticate(AuthenticateLoginDto dto);
    }
}
