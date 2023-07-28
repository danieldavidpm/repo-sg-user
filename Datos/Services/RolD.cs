using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto.RolDto;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    public class RolD : IRolD
    {
        private DbContextConfig _context;
        private RolMapper _map = new RolMapper();

        public RolD(DbContextConfig context)
        {
            _context = context;
        }

        public async Task<RolAddDto> AddAsync(RolAddDto dto)
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
            var entityToDelete = await _context.Rol.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.Rol.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<RolGetAllDto>> GetAll()
        {
            var lst = (from a in _context.Rol
                       select new RolGetAllDto
                       {
                           Id = a.Id,
                           Nombre = a.Nombre,
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<RolGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.Rol
                          where a.Id == id
                          select new RolGetAllDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<string> UpdateAsync(RolAddDto dto)
        {
            var entityToUpdate = await _context.Set<Rol>().FindAsync(dto.Id);

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
