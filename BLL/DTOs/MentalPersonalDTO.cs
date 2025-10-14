

namespace BLL.DTOs
{
    public  class MentalPersonalDTO
    {
        public int IdHistoriaClinica { get; set; }
        public string? DiscapacidadCognitiva { get; set; }
        public string? Epilepsia { get; set; }
        public string? EnfermedadesFamiliaresHeredables { get; set; }
        public string? ConsumoDeSustanciasPsicoactivas { get; set; }
        public string? ConsumoDeAlcohol { get; set; }
        public string? DxDeSaludMental { get; set; }
        public string? IntentoDeSuicidio { get; set; }
        public string? EventosTraumaticos { get; set; }
        public string? SeEncuentraMedicado { get; set; }
        public string? AntecedentesDeAutolesion { get; set; }
        public string? InternacionesEnCentrosPsiquiatricos { get; set; }
        public string? Observaciones { get; set; }
        public int IdUsuario { get; set; }
    }
}
