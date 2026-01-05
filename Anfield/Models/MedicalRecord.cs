using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [DisplayName("Visit Date")]
        public DateTime VisitDate { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Prescription { get; set; }
        // Other relevant properties

        // Navigation property
        public Patient Patient { get; set; }
    }
}
