using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Order;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IOrderItemRepository : IScopedDependency
{
    void AddOrderItem(OrderItem orderItem);
    void UpdateOrderItem(OrderItem orderItem);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<ICollection<OrderItemDTO>?> GetOrderItemDTOsByOrderId(int orderId, CancellationToken cancellation);
    Task<OrderItem?> GetOrderItemById(int id, CancellationToken cancellation);
    Task<int> GetCountOfCurrentShopItems(int openOrderId, CancellationToken cancellation);
    Task<ICollection<OrderItem>?> GetOrderItemsByOrderId(int orderId, CancellationToken cancellation);
}
