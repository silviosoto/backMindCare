using Domain.Models;


namespace Domain.DTO
{
    public class paymethpsychologistDTO
    { 
        public DateTime? FechaEmision { get; set; }
        public string NumeroFactura {  get; set; }
        public string Servicio {  get; set; }
        public int idPaciente {  get; set; }
        public string Nombre_paciente {  get; set; }
        public int idPsicologo { get; set; }
        public string Nombre_psicologo { get; set; }
        public decimal Total_pago_paciente { get; set; }
        public int Estado { get; set; }
        public decimal total_pagado_psicologo { get; set; }
        public decimal saldo_pendiente { get; set; }

    }
}
