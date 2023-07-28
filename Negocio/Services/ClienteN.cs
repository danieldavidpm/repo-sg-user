using Datos.Interfaces;
using Datos.Services;
using Entidades.Dto.ClienteDto;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ClienteN : IClienteN
    {
        private readonly IClienteD _IClienteD;
        public ClienteN(IClienteD IClienteD)
        {
            _IClienteD = IClienteD;
        }

        public Task<ClienteAddDto> AddAsync(ClienteAddDto dto)
        {
            return _IClienteD.AddAsync(dto);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _IClienteD.DeleteAsync(id);
        }

        public Task<List<ClienteGetAllDto>> GetAll()
        {
            return _IClienteD.GetAll();
        }

        public Task<ClienteGetAllDto?> GetById(int id)
        {
            return _IClienteD.GetById(id);
        }

        public Task<string> UpdateAsync(ClienteAddDto dto)
        {
            return _IClienteD.UpdateAsync(dto);
        }
    }
}
