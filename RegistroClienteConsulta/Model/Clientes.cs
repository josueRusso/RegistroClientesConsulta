using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.Model
{
    public class Clientes
    {
        [Key] 
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre del cliente")]
        public string? Nombre { get; set;}
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la cédula del cliente")]
        [Range(minimum: 11, maximum: 11, ErrorMessage = "Debe estar en un rango permitido")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el RNC del cliente")]
        [Range(minimum: 9, maximum: 9, ErrorMessage = "Debe estar en un rango permitido")]
        public string? Rnc { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
    }
}
