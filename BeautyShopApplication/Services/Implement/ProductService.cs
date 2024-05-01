using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopApplication.Services.Implement;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly IProductItemRepository _productItemRepository;

    public ProductService(IProductRepository productRepository,IProductFeatureRepository productFeatureRepository,
        IProductItemRepository productItemRepository)
    {
        _productRepository = productRepository;
        _productFeatureRepository = productFeatureRepository;
        _productItemRepository = productItemRepository;
    }


    public async Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation)
    {
        var product = await _productRepository.GetProductById(productId, cancellation);
        if (product == null) return null;

        var dto = new ProductPageDTO()
        {
            CategoryId = product.CategoryId,
            Description = product.Description,
            DiscountPercentage = product.DiscountPercentage,
            GeneralImage = product.GeneralImage,
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ProductFeatures = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, cancellation),
            ProductItems = await _productItemRepository.GetProductItemDTOsByProductId(productId, cancellation)
        };

        return dto;
    }
}
