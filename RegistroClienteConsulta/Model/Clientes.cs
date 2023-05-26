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
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Debe estar en un rango permitido")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el RNC del cliente")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Debe estar en un rango permitido")]
        public string? Rnc { get; set; }

        public string? Email { get; set; }

        public string? Direccion { get; set; }
    }
}
