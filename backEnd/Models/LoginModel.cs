using System.ComponentModel.DataAnnotations;

namespace backEnd.Models
{
    public class LoginModel
    {
        public int ID { get; set; }
        [Required]
        public string user { get; set; }
        [Required]
        public string pass { get; set; }
        [Required]
        public string email { get; set; }
       
    }
}
