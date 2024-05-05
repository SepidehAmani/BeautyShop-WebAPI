using BeautyShopDomain.Enums;

namespace BeautyShopDomain.DTOs.AdminSide;

public class OrderDetailDTO
{
    public int OrderId { get; set; }
    public string UserName { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItemDetailDTO> Items { get; set; }
}
