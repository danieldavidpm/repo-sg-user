using AccesoDatos;
using Datos.Interfaces;
using Entidades.Dto.UsuAppDto;
using Negocio.Interfaces;

namespace Negocio.Services
{
    public class UsuAppN : IUsuAppN
    {
        private DbContextConfig _context;
        private readonly IUsuAppD _IUsuAppD;

        public UsuAppN(DbContextConfig context, IUsuAppD IUsuAppD)
        {
            _context = context;
            _IUsuAppD = IUsuAppD;
        }

        public Task<UsuAppAddDto> AddAsync(UsuAppAddDto dto)
        {
            return _IUsuAppD.AddAsync(dto);
        }
        public Task<string> UpdateAsync(UsuAppAddDto dto)
        {
            return _IUsuAppD.UpdateAsync(dto);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _IUsuAppD.DeleteAsync(id);
        }

        public Task<List<UsuAppGetAllDto>> GetAll()
        {
            return _IUsuAppD.GetAll();
        }

        public Task<UsuAppGetAllDto?> GetById(int id)
        {
            return _IUsuAppD.GetById(id);
        }

        public Task<List<UsuAppGetAppsXUsuDto?>> GetAppsByIdUse(int id)
        {
            return _IUsuAppD.GetAppsByIdUse(id);
        }
    }
}
