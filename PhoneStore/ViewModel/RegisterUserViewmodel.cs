using PhoneStore.Models;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.ViewModel
{
    public class RegisterUserViewmodel
        
    {
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? NumbersofOrders { get; set; } 
        public List<CityUser> CityUsers { get; set; }
        public List<CountryUser>CountryUsers { get; set; }
    }
}
