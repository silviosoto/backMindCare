

namespace BLL.DTOs
{
    public  class ConceptoPsicologicoDTO
    {
        public int IdHistoriaClinica { get; set; }
        public string? DiagnosticoPrincipal { get; set; }
        public string? DiagnosticoRelacionado1 { get; set; }
        public string? DiagnosticoRelacionado2 { get; set; }
        public string? PlanDeTratamiento { get; set; }
        public string? Objetivos { get; set; }
        public string? Recomendaciones { get; set; }
        public string? Compromisos { get; set; }
        public int IdUsuario { get; set; }
    }
}
