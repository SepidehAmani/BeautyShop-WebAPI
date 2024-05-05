using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.Entities.Order;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Open;
    public bool IsDelete { get; set; }
    public bool IsSeen { get; set; }


    public User.User? User { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}
