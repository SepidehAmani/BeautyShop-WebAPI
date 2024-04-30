using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class LoginUserDTO
{
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string MobileNumber { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
