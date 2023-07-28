using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto;
using Entidades.Dto.RolOpe;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{

    public class RolOpeD : IRolOpeD
    {
        private DbContextConfig _context;
        private RolOpeMapper _map = new RolOpeMapper();

        public RolOpeD(DbContextConfig context)
        {
            _context = context;
        }

        public async Task<RolOpeAddDto> AddAsync(RolOpeAddDto dto)
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
            var entityToDelete = await _context.RolOpe.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.RolOpe.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<RolOpeGetAllDto>> GetAll()
        {
            var lst = (from a in _context.RolOpe
                       select new RolOpeGetAllDto
                       {
                           Id = a.Id,
                           IdRol = a.IdRol,
                           IdOperaciones = a.IdOpe,
                           rol = new OptionDto
                           {
                               Id = a.rol.Id,
                               Nombre = a.rol.Nombre,
                               IsModificable = false
                           },
                           operacion = new OptionDto
                           {
                               Id = a.operaciones.Id,
                               Nombre = a.operaciones.Nombre,
                               IsModificable = false
                           }
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<RolOpeGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.RolOpe
                          where a.Id == id
                          select new RolOpeGetAllDto
                          {
                              Id = a.Id,
                              IdRol = a.IdRol,
                              IdOperaciones = a.IdOpe,
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<string> UpdateAsync(RolOpeAddDto dto)
        {
            var entityToUpdate = await _context.Set<RolOpe>().FindAsync(dto.Id);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                entityToUpdate.IdRol = dto.IdRol;
                entityToUpdate.IdOpe = dto.IdOperaciones;

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
