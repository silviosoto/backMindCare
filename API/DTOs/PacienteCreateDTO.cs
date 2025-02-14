

using API.DTOs;

namespace API.Models.DTOs
{
    public class PacienteCreateDTO
    {
        public IFormFile? file { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string? Validado { get; set; }
        public DatosPersonaleCreateDTO datosPersonale { get; set; }
        public int? Experiencia { get; set; }
        public string? sugerencias { get; set; }

    }
}
