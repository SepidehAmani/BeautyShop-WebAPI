using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class EditUserDTO
{
    [Required]
    [MinLength(4)]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string MobileNumber { get; set; }
    [Required]
    public ICollection<string>? Roles { get; set; }
}
