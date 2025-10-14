

namespace BLL.DTOs
{
    public  class RazonesSintomasConductaDTO
    {
        public int IdHistoriaClinica { get; set; } 
        public string? RelacionadosAmbientesFamiliares { get; set; }
        public string? RelacionadosAmbienteSocial { get; set; }
        public string? RelacionadosAmbientesAcademicos { get; set; }
        public string? RelacionadosCaracteristicasDelIndividuo { get; set; }
        public int IdUsuario { get; set; }
    }
}
