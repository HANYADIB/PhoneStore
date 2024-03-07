using System.ComponentModel.DataAnnotations;

namespace PhoneStore.ViewModel
{
    public class changepasswordviewmodel
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Not Matching")]
        public string ComfirmPassword { get; set; } 
    }
}
