using BeautyShopDomain.DTOs;

namespace BeautyShopApplication.Services.Interface;

public interface IOrderService
{
    Task<bool> AddItemToShopCard(AddToShopCardDTO addToShopCardDTO, int userId, CancellationToken cancellation);
    Task<ShowShopCardDTO?> GetShopCard(int userId, CancellationToken cancellation);
    Task<bool> RemoveItemFromShopCard(int orderItemId, int userId, CancellationToken cancellation);
    Task<bool> RemoveShopCard(int userId, CancellationToken cancellation);
}
