using Datos.Interfaces;
using Entidades.Dto.RolDto;
using Negocio.Interfaces;

namespace Negocio.Services
{
    public class RolN : IRolN
    {
        private readonly IRolD _IRolD;

        public RolN(IRolD IRolD)
        {
            _IRolD = IRolD;
        }

        public Task<RolAddDto> AddAsync(RolAddDto dto)
        {
            return _IRolD.AddAsync(dto);
        }
        public Task<string> UpdateAsync(RolAddDto dto)
        {
            return _IRolD.UpdateAsync(dto);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _IRolD.DeleteAsync(id);
        }

        public Task<List<RolGetAllDto>> GetAll()
        {
            return _IRolD.GetAll();
        }

        public Task<RolGetAllDto?> GetById(int id)
        {
            return _IRolD.GetById(id);
        }
    }
}
