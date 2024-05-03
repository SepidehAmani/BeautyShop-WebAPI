using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class CreateImageDTO
{
    [Required]
    public IFormFile ImageFile { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
}
