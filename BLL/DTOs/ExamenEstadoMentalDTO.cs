

namespace BLL.DTOs
{
    public  class ExamenEstadoMentalDTO
    {
        public int IdHistoriaClinica { get; set; }
        public string? NivelDeConciencia { get; set; }
        public string? Atencion { get; set; }
        public string? Sensopercepcion { get; set; }
        public string? Afecto { get; set; }
        public string? Lenguaje { get; set; }
        public string? Orientacion { get; set; }
        public string? Sueno { get; set; }
        public string? Pensamiento { get; set; }
        public string? ConductaMotora { get; set; }
        public string? Memoria { get; set; }
        public string? PatronDeAlimentacion { get; set; }
        public string? Inteligencia { get; set; }
        public string? NivelDeRazonamiento { get; set; }
        public string? PorteYActitud { get; set; }
        public int IdUsuario { get; set; }
    }
}
