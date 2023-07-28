using AccesoDatos;
using Datos.Interfaces;
using Datos.Mappers;
using Datos.Services;
using Entidades;
using Entidades.Dto.UsuarioDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Negocio.Interfaces;
using System.Data;

namespace Negocio.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private SqlConnectionFactory _sqlConnectionFactory;
        private UsuarioMapper _map = new UsuarioMapper();

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _sqlConnectionFactory = new SqlConnectionFactory(configuration);
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                var usuario = await GetLogin(userId.Value);
                context.Items["Usuario"] = usuario;
            }

            UsuarioGetAllDto usuarioGetAllDto = new UsuarioGetAllDto();

            await _next(context);
        }

        private async Task<Usuario> GetLogin(int id)
        {
            using (SqlConnection sql = _sqlConnectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[SP_USUARIO_EXISTE]", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    var response = new Usuario();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            return new Usuario()
                            {
                                Nombre = (string)reader["Nombre"],
                                Email = (string)reader["Email"],
                                ImagenPerfil = (string)reader["ImagenPerfil"],
                                FechaVencimiento = (DateTime)reader["FechaVencimiento"],
                                IdRol = (int)reader["IdRol"],
                                IdCliente = (int)reader["IdCliente"],
                            };
                    }

                    return response;
                }
            }
        }

    }

}
