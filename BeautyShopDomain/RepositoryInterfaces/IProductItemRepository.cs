using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductItemRepository
{
    Task<ICollection<ProductItemDTO>?> GetProductItemDTOsByProductId(int productId, CancellationToken cancellation);
    Task<ICollection<ProductItem>?> GetProductItemsByProductId(int productId, CancellationToken cancellation);
    void AddProductItem(ProductItem item);
    void UpdateProductItem(ProductItem item);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<bool> ProductItemExistsWithId(int productItemId, CancellationToken cancellation);
    Task<ProductItem?> GetProductItemById(int id, CancellationToken cancellation);
    Task<ProductItem?> GetProductItemWithProductById(int id, CancellationToken cancellation);
}
