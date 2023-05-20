using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.Model
{
    public class Cliente
    {
        [Key] public int ClienteId { get; set; }    
        public string? Nombre { get; set;}
        public double Telefono { get; set; }
        public double Cedula { get; set; } 
        public double Rnc { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
    }
}
