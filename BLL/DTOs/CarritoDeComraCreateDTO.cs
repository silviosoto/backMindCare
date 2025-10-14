
namespace BLL.DTOs
{
    public class CarritoDeComraCreateDTO
    {
        
        public int IdPsicologo { get; set; }
        public int IdPaciente { get; set; }
        public int IdServicio { get; set; }
        public Boolean EsPaquete { get; set; }
        public decimal ValorServicio { get; set; }
        public int? NumeroSesiones { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime? Fecha { get; set; }
        public string MotivoConsulta { get; set; }
    }
}
