using AccesoDatos;
using Datos.Interfaces;
using Entidades.Dto.AppDto;
using Negocio.Interfaces;

namespace Negocio.Services
{
    public class AppN : IAppN
    {
        private DbContextConfig _context;
        private readonly IAppD _IAppD;

        public AppN(DbContextConfig context, IAppD IAppD)
        {
            _context = context;
            _IAppD = IAppD;
        }

        public Task<AppAddDto> AddAsync(AppAddDto dto)
        {
            return _IAppD.AddAsync(dto);
        }
        public Task<string> UpdateAsync(AppAddDto dto)
        {
            return _IAppD.UpdateAsync(dto);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _IAppD.DeleteAsync(id);
        }

        public Task<List<AppGetAllDto>> GetAll()
        {
            return _IAppD.GetAll();
        }

        public Task<AppGetAllDto?> GetById(int id)
        {
            return _IAppD.GetById(id);
        }

    }
}
