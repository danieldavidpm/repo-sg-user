using AccesoDatos;
using Datos.Interfaces;
using Entidades.Dto.RolOpe;
using Negocio.Interfaces;

namespace Negocio.Services
{
    public class RolOpeN : IRolOpeN
    {
        private DbContextConfig _context;
        private readonly IRolOpeD _IRolOpeD;

        public RolOpeN(DbContextConfig context, IRolOpeD IRolOpeD)
        {
            _context = context;
            _IRolOpeD = IRolOpeD;
        }

        public Task<RolOpeAddDto> AddAsync(RolOpeAddDto dto)
        {
            return _IRolOpeD.AddAsync(dto);
        }
        public Task<string> UpdateAsync(RolOpeAddDto dto)
        {
            return _IRolOpeD.UpdateAsync(dto);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _IRolOpeD.DeleteAsync(id);
        }

        public Task<List<RolOpeGetAllDto>> GetAll()
        {
            return _IRolOpeD.GetAll();
        }

        public Task<RolOpeGetAllDto?> GetById(int id)
        {
            return _IRolOpeD.GetById(id);
        }

    }
}
