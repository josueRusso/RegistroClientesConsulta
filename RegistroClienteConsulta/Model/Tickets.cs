using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.Model
{
    public class Tickets
    {
        [Key]
        public int TicketIdId { get; set; }

        [Range(minimum: 0, maximum: 50, ErrorMessage = "Debe estar en un rango permitido")]
        public int Fecha { get; set; }

        public int ClienteId { get; set; }

        public int SistemaId { get; set; }

        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el por quien fue solicitado")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir Un Asunto")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una Descripcion")]
        public string? Descripcion { get; set; }
    }
}
