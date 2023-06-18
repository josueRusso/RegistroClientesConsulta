using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistroClienteConsulta.Model
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        public DateTime FechaT { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }

        public int SistemaId { get; set; }

        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el por quien fue solicitado")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir Un Asunto")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una Descripcion")]
        public string? Descripcion { get; set; }

        [ForeignKey("TicketId")]
        public List<TicketsDetalle> Detalle { get; set; } = new List<TicketsDetalle>();
    }

    public class TicketsDetalle 
    {
        [Key]
        public int TicketsDetalleId { get; set; } 
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una Emisor")]
        public string Emisor { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una Mensaje")]
        public string Mensaje { get; set; }

    }
       
}
