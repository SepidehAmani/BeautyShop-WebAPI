using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductRepository
{
    Task<Product?> GetProductById(int id, CancellationToken cancellation);
}
