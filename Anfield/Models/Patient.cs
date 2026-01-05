using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Date Of Birth")] 
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
        // Other relevant properties
    }
}
