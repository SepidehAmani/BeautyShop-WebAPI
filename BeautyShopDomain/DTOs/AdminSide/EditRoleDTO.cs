using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class EditRoleDTO
{
    [Required]
    [MinLength(3)]
    public string RoleUniqueName { get; set; }
}
