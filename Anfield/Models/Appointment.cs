using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [DisplayName("Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Notes { get; set; }
        // Other relevant properties

        // Navigation property
        public Patient Patient { get; set; }
    }
}
