using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class CreateProductFeatureDTO
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}
