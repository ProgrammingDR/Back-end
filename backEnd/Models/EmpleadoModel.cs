using System.ComponentModel.DataAnnotations;

namespace backEnd.Models
{
    public class EmpleadoModel
    {
       
        public int ID { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string cedula { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        public string numero { get; set; }
        [Required]
        public string direccion { get; set; }
    }
}
