using BeautyShopDomain.DTOs;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductFeatureRepository
{
    Task<ICollection<ProductFeatureDTO>?> GetProductFeatureDTOsByProductId(int productId, CancellationToken cancellation);
}
