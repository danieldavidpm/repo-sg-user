namespace Entidades.Dto.RolOpe
{
    public class RolOpeGetAllDto
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdOperaciones { get; set; }
        public OptionDto? rol { get; set; }
        public OptionDto? operacion { get; set; }
    }
}
