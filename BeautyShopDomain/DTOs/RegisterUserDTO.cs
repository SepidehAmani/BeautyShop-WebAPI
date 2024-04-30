using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class RegisterUserDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Mobile { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string RePassword { get; set; }
}
