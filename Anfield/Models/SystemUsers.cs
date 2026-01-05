using Microsoft.AspNetCore.Identity;


namespace Anfield.Models
{
    public class SystemUsers: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
