using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.Model
{
    public class Prioridades
    {
        [Key] 
        public int PrioridadId { get; set; }

        public string? Descripcion { get; set; }

        public DateTime DiasCompromiso { get; set; } = DateTime.Now;
    }
}
