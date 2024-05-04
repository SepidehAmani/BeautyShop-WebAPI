namespace BeautyShopDomain.DTOs;

public class ShowShopCardDTO
{
    public int OrderId { get; set; }
    public DateTime CreateDate { get; set; }
    public ICollection<OrderItemDTO>? orderItems { get; set; }
}
