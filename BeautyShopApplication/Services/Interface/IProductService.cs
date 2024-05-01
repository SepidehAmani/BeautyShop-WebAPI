using BeautyShopDomain.DTOs;

namespace BeautyShopApplication.Services.Interface;

public interface IProductService
{
    Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation);
}
