using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class RegisterUserDTO
{
    public string UserName { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string RePassword { get; set; }
}
