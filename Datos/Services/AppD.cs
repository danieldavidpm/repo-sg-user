using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto.AppDto;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    public class AppD : IAppD
    {
        private DbContextConfig _context;
        private AppMapper _map = new AppMapper();

        public AppD(DbContextConfig context)
        {
            _context = context;
        }

        public async Task<AppAddDto> AddAsync(AppAddDto dto)
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
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _context.App.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.App.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<AppGetAllDto>> GetAll()
        {

            var lst = (from a in _context.App
                       select new AppGetAllDto
                       {
                           Id = a.Id,
                           Nombre = a.Nombre,
                           Descripcion = a.Descripcion,
                           ImagenApp = a.ImagenApp,
                           ContainerDeAdjuntos = a.ContainerDeAdjuntos,
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<AppGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.App
                          where a.Id == id
                          select new AppGetAllDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                              Descripcion = a.Descripcion,
                              ImagenApp = a.ImagenApp,
                              ContainerDeAdjuntos = a.ContainerDeAdjuntos,
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<string> UpdateAsync(AppAddDto dto)
        {
            var entityToUpdate = await _context.Set<App>().FindAsync(dto.Id);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                entityToUpdate.Nombre = dto.Nombre;
                entityToUpdate.Descripcion = dto.Descripcion;
                entityToUpdate.ImagenApp = dto.ImagenApp;
                entityToUpdate.ContainerDeAdjuntos = dto.ContainerDeAdjuntos;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return "Actualizado";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return ex.Message;
                throw;
            }
        }
    }
}
