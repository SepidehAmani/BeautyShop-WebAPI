using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.DTOs.AdminSide;

public class AdminSideProductDTO
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string? Description { get; set; }
    public string? GeneralImagePath { get; set; }


    public ICollection<ProductItemDTO>? ProductItems { get; set; }
    public ICollection<ProductFeatureDTO>? ProductFeatures { get; set; }
}
