using Common;
using Datos.Interfaces;
using Entidades.Dto.UsuarioDto;
using Negocio.Authorization;
using Negocio.Interfaces;

namespace Negocio.Services
{
    public class UsuarioN : IUsuarioN
    {
        private readonly IUsuarioD _IUsuarioD;
        private IJwtUtils _jwtUtils;

        public UsuarioN(IUsuarioD IUsuarioD, IJwtUtils jwtUtils)
        {
            _IUsuarioD = IUsuarioD;
            _jwtUtils = jwtUtils;
        }

        public Task<JsonResult<UsuarioAddDto>> AddAsync(UsuarioAddDto dto)
        {
            return _IUsuarioD.AddAsync(dto);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _IUsuarioD.DeleteAsync(id);
        }

        public Task<List<UsuarioGetAllDto>> GetAll()
        {
            return _IUsuarioD.GetAll();
        }

        public Task<UsuarioGetAllDto?> GetById(int id)
        {
            return _IUsuarioD.GetById(id);
        }

        public Task<JsonResult<UsuarioAddDto>> UpdateAsync(UsuarioAddDto dto)
        {
            return _IUsuarioD.UpdateAsync(dto);
        }

        public async Task<AuthenticateDto?> GetAuthenticate(AuthenticateLoginDto dto)
        {
            var entity = await _IUsuarioD.GetAuthenticate(dto);
            if (entity != null)
            {
                entity.Token = _jwtUtils.GenerateToken(entity);
                return entity;
            }
            else
                return null;
        }

    }
}
