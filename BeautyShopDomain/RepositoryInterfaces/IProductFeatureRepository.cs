using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductFeatureRepository
{
    Task<ICollection<ProductFeatureDTO>?> GetProductFeatureDTOsByProductId(int productId, CancellationToken cancellation);
    void AddProductFeature(ProductFeature productFeature);
    void UpdateProductFeature(ProductFeature productFeature);
    Task SaveChangesAsync(CancellationToken cancellation);
}
