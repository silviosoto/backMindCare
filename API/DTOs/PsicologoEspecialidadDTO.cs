namespace API.Models.DTOs
{
    public class PsicologoEspecialidadDTO
    {
        public int Id { get; set; }

        public int? IdPsicologo { get; set; }

        public int? IdEspecialidad { get; set; }

        public string? Validado { get; set; }

    }
}
