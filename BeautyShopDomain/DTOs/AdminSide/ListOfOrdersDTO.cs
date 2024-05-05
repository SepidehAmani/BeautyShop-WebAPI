using BeautyShopDomain.Enums;

namespace BeautyShopDomain.DTOs.AdminSide;

public class ListOfOrdersDTO
{
    public int OrderId { get; set; }
    public string UserName { get; set; }
    public OrderStatus Status { get; set; }
    public bool IsSeen { get; set; }
}
