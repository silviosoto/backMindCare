

namespace BLL.DTOs
{
    public  class HistoriaAcademicaDTO
    {
        public int IdHistoriaClinica { get; set; }
        public string? EdadDeIngresoALaEscuela { get; set; }
        public string? AdaptacionInicial { get; set; }
        public string? DesempenoAcademico { get; set; }
        public string? AnosPerdidos { get; set; }
        public string? CursoActual { get; set; }
        public string? MateriaQueSeFacilitaYLaQueSeDificulta { get; set; }
        public string? TiempoDiarioDeEstudioHoras { get; set; } 
        public int IdUsuario { get; set; }
    }
}
