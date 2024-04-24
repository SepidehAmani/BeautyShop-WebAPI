using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.Entities.Order;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public int ProductItemId { get; set; }
    public int OrderCount { get; set; }
    public bool IsDelete { get; set; }


    public Order? Order { get; set; }
    public ProductItem? ProductItem { get; set; }
}
