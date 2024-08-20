using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.Entities.Order;

namespace BeautyShopDomain.Entities.Product;

public class ProductItem : BaseEntity, IEntity
{
    public int ProductId { get; set; }
    public int? ImageId { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }
    public bool IsDelete { get; set; }
    

    public ICollection<OrderItem>? OrderItems { get; set; }
    public Product? Product { get; set; }
    public Image.Image? Image {  get; set; }
}
