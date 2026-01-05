using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class PatientAppointments
    {
        [Key]
        [Required]
        public int AppontmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Service { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}
