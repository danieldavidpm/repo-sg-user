using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto.ClienteDto;
using Entidades.Dto.RolDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Services
{
    public class ClienteD : IClienteD
    {
        private DbContextConfig _context;
        private ClienteMapper _map = new ClienteMapper();

        public ClienteD(DbContextConfig context)
        {
            _context = context;
        }
        public async Task<ClienteAddDto> AddAsync(ClienteAddDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = _map.MapToAdd(dto);
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return _map.MapToAdd(entity);
            }
            catch
            {
                await transaction.RollbackAsync();
                return dto;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _context.Cliente.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.Cliente.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<ClienteGetAllDto>> GetAll()
        {
            var lst = (from a in _context.Cliente
                       select new ClienteGetAllDto
                       {
                           Id = a.Id,
                           Nombre = a.Nombre,
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<ClienteGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.Cliente
                          where a.Id == id
                          select new ClienteGetAllDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<string> UpdateAsync(ClienteAddDto dto)
        {
            var entityToUpdate = await _context.Set<Cliente>().FindAsync(dto.Id);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                entityToUpdate.Nombre = dto.Nombre;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return "Actualizado";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return ex.Message;
            }
        }
    }
}
