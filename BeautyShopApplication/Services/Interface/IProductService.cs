using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;

namespace BeautyShopApplication.Services.Interface;

public interface IProductService
{
    Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation);
    bool ValidateImageFile(CreateImageDTO imageDTO);
    Task<AdminSideProductDTO?> CreateProduct(CreateProductDTO productDTO, CancellationToken cancellation);
    Task<AdminSideProductDTO?> CreateProductItem(CreateProductItemDTO productItemDTO, int productId, CancellationToken cancellation);
}
