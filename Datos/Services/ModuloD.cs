using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto.ModuloDto;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    public class ModuloD : IModuloD
    {
        private DbContextConfig _context;
        private ModuloMapper _map = new ModuloMapper();

        public ModuloD(DbContextConfig context)
        {
            _context = context;
        }

        public async Task<ModuloAddDto> AddAsync(ModuloAddDto dto)
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
            var entityToDelete = await _context.Modulo.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.Modulo.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<ModuloGetAllDto>> GetAll()
        {
            var lst = (from a in _context.Modulo
                       select new ModuloGetAllDto
                       {
                           Id = a.Id,
                           Nombre = a.Nombre,
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<ModuloGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.Modulo
                          where a.Id == id
                          select new ModuloGetAllDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<string> UpdateAsync(ModuloAddDto dto)
        {
            var entityToUpdate = await _context.Set<Modulo>().FindAsync(dto.Id);

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
