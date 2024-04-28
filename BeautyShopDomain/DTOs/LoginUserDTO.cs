using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class LoginUserDTO
{
    public string Mobile { get; set; }
    public string Password {  get; set; }
}
