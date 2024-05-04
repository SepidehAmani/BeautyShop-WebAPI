using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Enums;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories; 

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Order?> GetOpenOrderByUserId(int userId,CancellationToken cancellation)
    {
        return await _context.Orders
            .FirstOrDefaultAsync(p => p.UserId == userId && p.Status == OrderStatus.Open && !p.IsDelete);
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
    }

    public void UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }
}
