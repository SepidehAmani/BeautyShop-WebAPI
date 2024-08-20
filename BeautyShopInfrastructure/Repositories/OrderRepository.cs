using BeautyShopDomain.DTOs.AdminSide;
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
        return await _context.Set<Order>()
            .FirstOrDefaultAsync(p => p.UserId == userId && p.Status == OrderStatus.Open && !p.IsDelete);
    }

    public void AddOrder(Order order)
    {
        _context.Set<Order>().Add(order);
    }

    public void UpdateOrder(Order order)
    {
        _context.Set<Order>().Update(order);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }


    public async Task<Order?> GetClosedOrderById(int orderId,CancellationToken cancellation)
    {
        return await _context.Set<Order>().FirstOrDefaultAsync(p => p.Id == orderId && p.Status == OrderStatus.Closed && !p.IsDelete, cancellation);
    }


    public async Task<ICollection<Order>?> GetListOfPayedOrders(CancellationToken cancellation)
    {
        return await _context.Set<Order>()
            .Where(p => !p.IsDelete && (p.Status == OrderStatus.Payed || p.Status == OrderStatus.Shipped))
            .ToListAsync(cancellation);
    }


    public async Task<Order?> GetOrderWithItemsById(int orderId,CancellationToken cancellation)
    {
        return await _context.Set<Order>().Where(p => p.Id == orderId && !p.IsDelete)
            .Include(p => p.OrderItems).FirstOrDefaultAsync(cancellation);
    }

    public async Task<Order?> GetOrderById(int orderId, CancellationToken cancellation)
    {
        return await _context.Set<Order>().Where(p => p.Id == orderId && !p.IsDelete).FirstOrDefaultAsync(cancellation);
    }
}
