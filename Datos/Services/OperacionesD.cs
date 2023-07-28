using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto.OperacionesDto;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    public class OperacionesD : IOperacionesD
    {
        private DbContextConfig _context;
        private OperacionesMapper _map = new OperacionesMapper();

        public OperacionesD(DbContextConfig context)
        {
            _context = context;
        }

        public async Task<OperacionesAddDto> AddAsync(OperacionesAddDto dto)
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
            var entityToDelete = await _context.Operaciones.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.Operaciones.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<OperacionesGetAllDto>> GetAll()
        {
            var lst = (from a in _context.Operaciones
                       select new OperacionesGetAllDto
                       {
                           Id = a.Id,
                           Nombre = a.Nombre,
                           IdModulo = a.IdMod
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<OperacionesGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.Operaciones
                          where a.Id == id
                          select new OperacionesGetAllDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                              IdModulo = a.IdMod
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<string> UpdateAsync(OperacionesAddDto dto)
        {
            var entityToUpdate = await _context.Set<Operaciones>().FindAsync(dto.Id);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                entityToUpdate.Nombre = dto.Nombre;
                entityToUpdate.IdMod = dto.IdModulo;

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
