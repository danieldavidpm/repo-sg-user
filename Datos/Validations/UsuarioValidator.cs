using AccesoDatos;
using Common;
using Entidades;
using Entidades.Dto.UsuarioDto;
using System.Net.Mail;

namespace Datos.Validations
{
    public class UsuarioValidator
    {
        private DbContextConfig _context;
        ErrorAccumulator errorAccumulator = new ErrorAccumulator();

        public UsuarioValidator(DbContextConfig context)
        {
            _context = context;
        }

        public List<Error> UsuarioAdd(Usuario usuario)
        {
            ValidarClaveForanea(usuario.IdRol);
            ValidateEmail(usuario.Email);

            List<Error> accumulatedErrors = errorAccumulator.GetErrors();

            return accumulatedErrors;
        }

        public async Task<List<Error>> UsuarioUpdate(UsuarioAddDto usuario)
        {
            await ValidarExisteRegistro(usuario.Id);
            ValidarClaveForanea(usuario.IdRol);
            ValidateEmail(usuario.Email);

            List<Error> accumulatedErrors = errorAccumulator.GetErrors();

            return accumulatedErrors;
        }

        private async Task<bool> ValidarExisteRegistro(int idUsuario)
        {
            var entityToUpdate = await _context.Set<Usuario>().FindAsync(idUsuario);            
            if (entityToUpdate == null)
            {
                errorAccumulator.AddError("Error: IdUsuario no existe!");
                return true;
            }

            return false;
        }

        private bool ValidarClaveForanea(int tablaRelacionadaId)
        {
            var tablaRelacionada = _context.Rol.Find(tablaRelacionadaId);
            if (tablaRelacionada == null)
            {
                errorAccumulator.AddError("Error: IdRol no existe!");
                return true;
            }

            return false;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return false;
            }
            catch (FormatException)
            {
                errorAccumulator.AddError("Error: Email no válido");
                return true;
            }
        }

    }
}
