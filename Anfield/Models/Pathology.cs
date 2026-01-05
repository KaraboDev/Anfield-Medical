using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class Pathology
    {
        [Key] 
        public int StaffId { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set;}
        [Required]
        public string PatientName { get; set;}
        [Required]
        public string PatientLastName { get; set;}
        [Required]
        public string TestDescription { get; set;}
        [Required]
        public DateTime DateTime { get; set;}
    }
}
