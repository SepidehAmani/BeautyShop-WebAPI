namespace BeautyShopDomain.DTOs;

public class ProductBoxDTO
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string? GeneralImagePath { get; set; }
}
