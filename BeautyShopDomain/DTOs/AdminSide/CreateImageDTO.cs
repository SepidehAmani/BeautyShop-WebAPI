using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class CreateImageDTO
{
    public IFormFile? ImageFile { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
