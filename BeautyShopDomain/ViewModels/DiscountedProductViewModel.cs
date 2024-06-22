using BeautyShopDomain.Entities.Image;

namespace BeautyShopDomain.ViewModels;

public class DiscountedProductViewModel
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public int FinalPrice { get; set; }
    public bool IsDelete { get; set; }

    public int? GeneralImageId { get; set; }
    public Image? GeneralImage { get; set; }
}
