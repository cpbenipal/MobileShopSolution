using System;
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
    public class RegisterResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; } 
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
    public class LoginDto
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class UserListDto 
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
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        [Display(Name = "Active")]
        public string IsActive { get; set; }
        public DateTime AddedOn { get; set; }
        public long AddedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long ModifiedBy { get; set; } 
    }
    public class LoginResponseDto 
    {
        public long Id { get; set; }        
        public string Email { get; set; }
        public string FullName { get; set; } = "Customer";
        public string RoleName { get; set; }
        public int IsActive { get; set; }         
    }
}