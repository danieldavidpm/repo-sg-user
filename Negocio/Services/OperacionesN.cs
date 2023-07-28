using AccesoDatos;
using Datos.Interfaces;
using Entidades.Dto.AppDto;
using Entidades.Dto.OperacionesDto;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class OperacionesN : IOperacionesN
    {
        private DbContextConfig _context;
        private readonly IOperacionesD _IOperacionesD;

        public OperacionesN(DbContextConfig context, IOperacionesD IOperacionesD)
        {
            _context = context;
            _IOperacionesD = IOperacionesD;
        }

        public Task<OperacionesAddDto> AddAsync(OperacionesAddDto dto)
        {
            return _IOperacionesD.AddAsync(dto);
        }
        public Task<string> UpdateAsync(OperacionesAddDto dto)
        {
            return _IOperacionesD.UpdateAsync(dto);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _IOperacionesD.DeleteAsync(id);
        }

        public Task<List<OperacionesGetAllDto>> GetAll()
        {
            return _IOperacionesD.GetAll();
        }

        public Task<OperacionesGetAllDto?> GetById(int id)
        {
            return _IOperacionesD.GetById(id);
        }

    }
}
