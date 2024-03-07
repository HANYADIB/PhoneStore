using Microsoft.AspNetCore.Identity;

namespace PhoneStore.Models
{
    public class ApplacationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
