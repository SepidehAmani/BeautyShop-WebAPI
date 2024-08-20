using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.Image;

namespace BeautyShopDomain.Entities.Product
{
    public class Product : BaseEntity, IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public string? Description { get; set; }
        public int? GeneralImageId { get; set; }
        public bool IsDelete {  get; set; }


        public ICollection<ProductItem>? ProductItems { get; set; }
        public ICollection<ProductFeature>? ProductFeatures { get; set; }
        public Category? Category { get; set; }
        public Image.Image? GeneralImage { get; set; }
    }
}
