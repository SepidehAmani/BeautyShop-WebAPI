using BeautyShopDomain.Entities.Base;

namespace BeautyShopDomain.Entities.Product;

public class ProductFeature : BaseEntity
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public Product? Product { get; set; }
}
