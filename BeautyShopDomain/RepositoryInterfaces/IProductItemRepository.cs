using BeautyShopDomain.DTOs;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductItemRepository
{
    Task<ICollection<ProductItemDTO>?> GetProductItemDTOsByProductId(int productId, CancellationToken cancellation);
}
