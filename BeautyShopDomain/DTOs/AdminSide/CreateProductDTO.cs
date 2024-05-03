using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class CreateProductDTO
{
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Price { get; set; }
    [Range(0,100)]
    public int DiscountPercentage { get; set; }
    public string? Description { get; set; }
    public CreateImageDTO? ImageDTO { get; set; }

}
