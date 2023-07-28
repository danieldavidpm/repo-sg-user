namespace Entidades.Dto.UsuarioDto
{
    public class UsuarioAddDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImagenPerfil { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdRol { get; set; }
        //public Rol? rol { get; set; }
        //public OptionDto? rol { get; set; }
        public int IdCliente { get; set; }
    }
}
