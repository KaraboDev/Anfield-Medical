using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class ChronicMedication
    {
        [Key]
        public int MedicationId { get; set; }
        [Required]
        [DisplayName("Medication Name")]
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        [Required]
        [DisplayName("Route Of Administration")]
        public string RouteOfAdministration { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [DisplayName("Side Effects")]
        public string SideEffects { get; set; }
    }
}
