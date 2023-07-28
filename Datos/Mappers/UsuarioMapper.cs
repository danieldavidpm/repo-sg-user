using Entidades;
using Entidades.Dto.UsuarioDto;

namespace Datos.Mappers
{
    using BCrypt.Net;
    public class UsuarioMapper
    {
        public Usuario MapToAdd(UsuarioAddDto dto)
        {
            return new Usuario()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Password = BCrypt.HashPassword(dto.Password),
                ImagenPerfil = dto.ImagenPerfil,
                FechaVencimiento = dto.FechaVencimiento,
                IdRol = dto.IdRol,
                IdCliente = dto.IdCliente,
            };
        }

        public UsuarioAddDto MapToAdd(Usuario dto)
        {
            if (dto is null)
                return new UsuarioAddDto();

            return new UsuarioAddDto()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Password = dto.Password,
                ImagenPerfil = dto.ImagenPerfil,
                FechaVencimiento = dto.FechaVencimiento,
                IdRol = dto.IdRol,
                IdCliente = dto.IdCliente
            };
        }

        public Usuario MapToUsuario(UsuarioGetAllDto dto)
        {
            if (dto is null)
                return new Usuario();

            return new Usuario()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Password = dto.Password,
                ImagenPerfil = dto.ImagenPerfil,
                FechaVencimiento = dto.FechaVencimiento,
                IdRol = dto.rol.Id,
                IdCliente = dto.cliente.Id,

            };
        }

    }
}
