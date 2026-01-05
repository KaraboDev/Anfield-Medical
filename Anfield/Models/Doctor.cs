using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        [Required]
        [DisplayName("Contact Name")]
        public string ContactNumber { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
