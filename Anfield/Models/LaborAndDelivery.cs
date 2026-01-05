using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class LaborAndDelivery
    {
        [Key]
        public int LaborAndDeliveryId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [DisplayName("Labor Start Date")]
        public DateTime LaborStartDate { get; set; }
        [Required]
        [DisplayName("Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        [Required]
        [DisplayName("Delivery Method")]
        public string DeliveryMethod { get; set; }
        // Other relevant properties

        // Navigation property
        public Patient Patient { get; set; }
    }
}
