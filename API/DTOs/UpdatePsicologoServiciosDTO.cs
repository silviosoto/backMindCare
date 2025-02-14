namespace API.DTOs
{
    public class UpdatePsicologoServiciosDTO
    {
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public int IdPsicologo { get; set; }
        public decimal Valor { get; set; }
    }
}
