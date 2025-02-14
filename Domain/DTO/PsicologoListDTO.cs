
namespace API.Models.DTOs
{
    public class PsicologoListDTO 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Descripcion { get; set; } 
        public int? Experiencia { get; set; }
       
        public string ImagePerfil { get; set; }

    }
}
