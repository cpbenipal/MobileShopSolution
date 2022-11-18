using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webMobileShop.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirm Password")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
    public class UserProfileDto
    {
        public long Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Address { get; set; }         
    }
}