using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class CreateRoleDTO
{
    [Required]
    [MinLength(3)]
    public string RoleUniqueName { get; set; }
}
