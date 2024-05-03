using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs.AdminSide;

public class CreateProductItemDTO
{
    [Required]
    public string Color { get; set; }
    [Required]
    public int Quantity { get; set; }
    public CreateImageDTO? ImageDTO { get; set; }
}
