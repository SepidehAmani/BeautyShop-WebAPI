﻿using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;
    public OrderItemRepository(AppDbContext context)
    {
        _context = context;
    }


    public void AddOrderItem(OrderItem orderItem)
    {
        _context.Set<OrderItem>().Add(orderItem);
    }

    public void UpdateOrderItem(OrderItem orderItem)
    {
        _context.Set<OrderItem>().Update(orderItem);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<ICollection<OrderItemDTO>?> GetOrderItemDTOsByOrderId(int orderId,CancellationToken cancellation)
    {
        return await _context.Set<OrderItem>().Where(p=> p.OrderId == orderId && !p.IsDelete)
            .Select(p=> new OrderItemDTO() { Id=p.Id,OrderCount=p.OrderCount,ProductItemId=p.ProductItemId})
            .ToListAsync(cancellation);
    }

    public async Task<OrderItem?> GetOrderItemById(int id,CancellationToken cancellation)
    {
        return await _context.Set<OrderItem>().FirstOrDefaultAsync(p=> p.Id == id && !p.IsDelete,cancellation);
    }


    public async Task<int> GetCountOfCurrentShopItems(int openOrderId,CancellationToken cancellation)
    {
        return await _context.Set<OrderItem>().Where(p => p.OrderId == openOrderId && !p.IsDelete).CountAsync(cancellation);
    }


    public async Task<ICollection<OrderItem>?> GetOrderItemsByOrderId(int orderId,CancellationToken cancellation)
    {
        return await _context.Set<OrderItem>().Where(p => p.OrderId == orderId && !p.IsDelete).ToListAsync(cancellation);
    }

}
