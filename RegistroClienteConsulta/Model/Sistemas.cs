using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.Model
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }

        [Required (ErrorMessage ="El nombre del sistema es obligatorio")]
        public String Nombre { get; set; }
    }
}
