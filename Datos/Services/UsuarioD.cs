using AccesoDatos;
using Common;
using Datos.Interfaces;
using Datos.Mappers;
using Datos.Validations;
using Entidades;
using Entidades.Dto;
using Entidades.Dto.UsuarioDto;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    using BCrypt.Net;
    public class UsuarioD : IUsuarioD
    {
        private DbContextConfig _context;
        private UsuarioMapper _map = new UsuarioMapper();
        private UsuarioValidator _usuarioValidator;

        public UsuarioD(DbContextConfig context)
        {
            _context = context;
            _usuarioValidator = new UsuarioValidator(_context);
        }

        public async Task<JsonResult<UsuarioAddDto>> AddAsync(UsuarioAddDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = _map.MapToAdd(dto);
                var validationResult = _usuarioValidator.UsuarioAdd(entity);
                if (validationResult.Count > 0)
                    return new JsonResult<UsuarioAddDto>(validationResult[0].IsValid, _map.MapToAdd(entity), "Favor de validar todos los campos", validationResult);

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return (new JsonResult<UsuarioAddDto>(_map.MapToAdd(entity)));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new JsonResult<UsuarioAddDto>(false, null, ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _context.Usuario.FirstOrDefaultAsync(e => e.Id == id);

            if (entityToDelete != null)
            {
                _context.Usuario.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<UsuarioGetAllDto>> GetAll()
        {
            var lst = (from a in _context.Usuario
                       select new UsuarioGetAllDto
                       {
                           Id = a.Id,
                           Nombre = a.Nombre,
                           Email = a.Email,
                           Password = a.Password,
                           ImagenPerfil = a.ImagenPerfil,
                           FechaVencimiento = a.FechaVencimiento,
                           rol = new OptionDto
                           {
                               Id = a.rol.Id,
                               Nombre = a.rol.Nombre,
                               IsModificable = false
                           },
                           cliente = new OptionDto
                           {
                               Id = a.cliente.Id,
                               Nombre = a.cliente.Nombre,
                               IsModificable = false
                           }

                       });

            return await Task.Factory.StartNew(() => { return lst.ToList(); });
        }

        public async Task<UsuarioGetAllDto?> GetById(int id)
        {
            var entity = (from a in _context.Usuario
                          where a.Id == id
                          select new UsuarioGetAllDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                              Email = a.Email,
                              Password = a.Password,
                              ImagenPerfil = a.ImagenPerfil,
                              FechaVencimiento = a.FechaVencimiento,
                              rol = new OptionDto
                              {
                                  Id = a.rol.Id,
                                  Nombre = a.rol.Nombre,
                                  IsModificable = false
                              },
                              cliente = new OptionDto
                              {
                                  Id = a.cliente.Id,
                                  Nombre = a.cliente.Nombre,
                                  IsModificable = false
                              }
                          });

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<JsonResult<UsuarioAddDto>> UpdateAsync(UsuarioAddDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            var entityToUpdate = new Usuario();
            try
            {
                var validationResult = await _usuarioValidator.UsuarioUpdate(dto);
                if (validationResult.Count > 0)
                {
                    entityToUpdate = await _context.Set<Usuario>().FindAsync(dto.Id);
                    return new JsonResult<UsuarioAddDto>(validationResult[0].IsValid, _map.MapToAdd(entityToUpdate), "Favor de validar todos los campos", validationResult);
                }

                entityToUpdate = await _context.Set<Usuario>().FindAsync(dto.Id);

                entityToUpdate.Nombre = dto.Nombre;
                entityToUpdate.Email = dto.Email;
                entityToUpdate.Password = dto.Password;
                entityToUpdate.ImagenPerfil = dto.ImagenPerfil;
                entityToUpdate.FechaVencimiento = dto.FechaVencimiento;
                entityToUpdate.IdRol = dto.IdRol;
                entityToUpdate.IdCliente = dto.IdCliente;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return (new JsonResult<UsuarioAddDto>(_map.MapToAdd(entityToUpdate)));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new JsonResult<UsuarioAddDto>(false, null, ex.Message);
            }
        }

        public async Task<AuthenticateDto?> GetAuthenticate(AuthenticateLoginDto dto)
        {
            var entity = (from a in _context.Usuario
                          where a.Email == dto.Email
                          select new AuthenticateDto
                          {
                              Id = a.Id,
                              Nombre = a.Nombre,
                              Email = a.Email,
                              Password = a.Password,
                              ImagenPerfil = a.ImagenPerfil,
                              FechaVencimiento = a.FechaVencimiento,
                              IdRol = a.IdRol,
                              IdCliente = a.IdCliente,
                          });

            var usuario = await entity.FirstOrDefaultAsync();
            if (usuario == null || !BCrypt.Verify(dto.Password, usuario.Password))
            {
                return null;
            }

            return usuario;
        }

    }
}
