using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anfield.Models
{
    public class UserRoles
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
