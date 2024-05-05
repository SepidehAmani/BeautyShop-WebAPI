﻿using BeautyShopDomain.Entities.Order;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IOrderRepository
{
    Task<Order?> GetOpenOrderByUserId(int userId, CancellationToken cancellation);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<Order?> GetClosedOrderById(int orderId, CancellationToken cancellation);
}
