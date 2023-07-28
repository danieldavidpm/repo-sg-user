using Entidades.Dto.ClienteDto;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Mappers
{
    public class ClienteMapper
    {
        public Cliente MapToAdd(ClienteAddDto dto)
        {
            return new Cliente()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public ClienteAddDto MapToAdd(Cliente dto)
        {
            return new ClienteAddDto()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }
    }
}
