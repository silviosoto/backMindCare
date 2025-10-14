

namespace BLL.DTOs
{
    public  class SignosFisicosDTO
    {
        public int IdHistoriaClinica { get; set; }
        public string? Laceraciones { get; set; }
        public string? Hematoma { get; set; }
        public string? Quemaduras { get; set; }
        public string? Cicatrices { get; set; }
        public string? Fracturas { get; set; }
        public string? Observaciones { get; set; }
        public int IdUsuario { get; set; }
    }
}
