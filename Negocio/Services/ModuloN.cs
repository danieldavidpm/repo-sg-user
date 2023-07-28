using AccesoDatos;
using Datos.Interfaces;
using Entidades.Dto.ModuloDto;
using Negocio.Interfaces;

namespace Negocio.Services
{
    public class ModuloN : IModuloN
    {
        private DbContextConfig _context;
        private readonly IModuloD _IModuloD;

        public ModuloN(DbContextConfig context, IModuloD IModuloD)
        {
            _context = context;
            _IModuloD = IModuloD;
        }

        public Task<ModuloAddDto> AddAsync(ModuloAddDto dto)
        {
            return _IModuloD.AddAsync(dto);
        }
        public Task<string> UpdateAsync(ModuloAddDto dto)
        {
            return _IModuloD.UpdateAsync(dto);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _IModuloD.DeleteAsync(id);
        }

        public Task<List<ModuloGetAllDto>> GetAll()
        {
            return _IModuloD.GetAll();
        }

        public Task<ModuloGetAllDto?> GetById(int id)
        {
            return _IModuloD.GetById(id);
        }

    }
}
