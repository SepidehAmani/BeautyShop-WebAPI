using BeautyShopDomain.DTOs;

namespace BeautyShopApplication.Services.Interface;

public interface ICategoryService
{
    Task<ICollection<ProductBoxDTO>?> GetProductDTOsByCategoryId(int categoryId,
        CategoryPageRequestDTO requestDTO, CancellationToken cancellation);
}
