using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class RegisterUserDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string MobileNumber { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string RePassword { get; set; }
}
