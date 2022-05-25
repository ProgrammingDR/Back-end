using System.ComponentModel.DataAnnotations;

namespace backEnd.Models
{
    public class VentaModel
    {
        public int ID { get; set; }
        [Required]
        public string tipo { get; set; }
        [Required]
        public string producto { get; set; }
        [Required]
        public string empleado { get; set; }
        [Required]
        public string cliente { get; set; }
        [Required]
        public string cantidad { get; set; }
        [Required]
        public string precio { get; set; }
        [Required]
        public string fecha { get; set; }

    }
}
