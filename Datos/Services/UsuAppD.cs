using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Entidades;
using Entidades.Dto;
using Entidades.Dto.UsuAppDto;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    public class UsuAppD : IUsuAppD
    {
        private DbContextConfig _context;
        private UsuAppMapper _map = new UsuAppMapper();

        public UsuAppD(DbContextConfig context)
        {
            _context = context;
        }

        public async Task<UsuAppAddDto> AddAsync(UsuAppAddDto dto)
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
            var entityToDelete = await _context.UsuApp.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.UsuApp.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<UsuAppGetAllDto>> GetAll()
        {
            var lst = (from a in _context.UsuApp
                       select new UsuAppGetAllDto
                       {
                           Id = a.Id,
                           IdUsuario = a.IdUsu,
                           IdApp = a.IdApp,
                           usuario = new OptionDto
                           {
                               Id = a.usuario.Id,
                               Nombre = a.usuario.Nombre,
                               IsModificable = false
                           },
                           app = new OptionDto
                           {
                               Id = a.app.Id,
                               Nombre = a.app.Nombre,
                               IsModificable = false
                           }
                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }


        public async Task<UsuAppGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.UsuApp
                          where a.Id == id
                          select new UsuAppGetAllDto
                          {
                              Id = a.Id,
                              IdUsuario = a.IdUsu,
                              IdApp = a.IdApp,
                          });

            return await entity.FirstOrDefaultAsync();
        }
        public async Task<List<UsuAppGetAppsXUsuDto?>> GetAppsByIdUse(int id)
        {
            var lst = (from ua in _context.UsuApp
                          join ap in _context.App
                          on ua.IdApp equals ap.Id
                          where ua.IdUsu == id
                          select new UsuAppGetAppsXUsuDto
                          {
                              Id = ua.Id,
                              IdApp = ap.Id,
                              Nombre = ap.Nombre,
                          });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }


        public async Task<string> UpdateAsync(UsuAppAddDto dto)
        {
            var entityToUpdate = await _context.Set<UsuApp>().FindAsync(dto.Id);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                entityToUpdate.IdUsu = dto.IdUsuario;
                entityToUpdate.IdApp = dto.IdApp;

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
