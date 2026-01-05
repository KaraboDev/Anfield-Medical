using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class Vaccine
    {
        [Key]
        public int VaccineId { get; set; }
        [Required]
        public string VaccineName { get; set; }
        [Required]
        public string VaccineType { get; set; }
        [Required]
        public string VaccineDescription { get; set; }
    }
}
