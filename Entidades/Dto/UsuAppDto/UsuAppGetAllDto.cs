namespace Entidades.Dto.UsuAppDto
{
    public class UsuAppGetAllDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdApp { get; set; }
        public OptionDto? usuario { get; set; }
        public OptionDto? app { get; set; }
    }
}
