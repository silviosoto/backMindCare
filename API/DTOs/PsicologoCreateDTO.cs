
namespace API.Models.DTOs
{
    public class PsicologoCreateDTO 
    {
        public IFormFile? file { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string? Validado { get; set; }
        public int IdDatosPersonales { get; set; }
        public int? Experiencia { get; set; }
        public string? sugerencias { get; set; }

    }
}
