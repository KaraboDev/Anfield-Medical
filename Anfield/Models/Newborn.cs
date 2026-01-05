using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class Newborn
    {
        [Key]
        public int NewbornId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [DisplayName("Birth Date")]
        public string HealthStatus { get; set; }
        // Other relevant properties

        // Navigation property
        public Patient Patient { get; set; }
    }
}
