using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;

namespace BeautyShopApplication.Services.Interface;

public interface IOrderService : IScopedDependency
{
    Task<bool> AddItemToShopCard(AddToShopCardDTO addToShopCardDTO, int userId, CancellationToken cancellation);
    Task<ShowShopCardDTO?> GetShopCard(int userId, CancellationToken cancellation);
    Task<bool> RemoveItemFromShopCard(int orderItemId, int userId, CancellationToken cancellation);
    Task<bool> RemoveShopCard(int userId, CancellationToken cancellation);
    Task<bool> PayShopCard(int userId,AddressDTO addressDTO, CancellationToken cancellation);
    Task<bool> OrderPayed(int orderId, int userId, CancellationToken cancellation);
    Task<ICollection<ListOfOrdersDTO>?> GetListOfPayedOrders(CancellationToken cancellation);
    Task<OrderDetailDTO?> GetPayedOrderInDetail(int OrderId, CancellationToken cancellation);
    Task<bool> ShippOrder(int orderId, CancellationToken cancellation);
}
