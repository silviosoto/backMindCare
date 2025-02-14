
namespace Domain.DTO
{
    public class PacienteUpdateDTO
    { 
        //public int Id { get; set; } 
        public bool? Estado { get; set; }
        public DatosPersonaleUpdateDTO datosPersonale { get; set; }
    }
}
