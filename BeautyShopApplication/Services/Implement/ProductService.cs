using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BeautyShopApplication.Services.Implement;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly IProductItemRepository _productItemRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFileService _fileService;

    public ProductService(IProductRepository productRepository, IProductFeatureRepository productFeatureRepository,
        IProductItemRepository productItemRepository, ICategoryRepository categoryRepository, IImageRepository imageRepository,
        IHttpContextAccessor httpContextAccessor, IFileService fileService)
    {
        _productRepository = productRepository;
        _productFeatureRepository = productFeatureRepository;
        _productItemRepository = productItemRepository;
        _categoryRepository = categoryRepository;
        _imageRepository = imageRepository;
        _httpContextAccessor = httpContextAccessor;
        _fileService = fileService;
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
            GeneralImage = _fileService.GetFileURL(product.GeneralImage.Path),
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ProductFeatures = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, cancellation),
            ProductItems = await _productItemRepository.GetProductItemDTOsByProductId(productId, cancellation)
        };

        return dto;
    }


    public bool ValidateImageFile(CreateImageDTO imageDTO)
    {
        var AllowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        if (!AllowedExtensions.Contains(Path.GetExtension(imageDTO.ImageFile.FileName)))
        {
            return false;
        }
        if (imageDTO.ImageFile.Length > 10485760)
        {
            return false;
        }
        return true;
    }

    public async Task<AdminSideProductDTO?> CreateProduct(CreateProductDTO productDTO, CancellationToken cancellation)
    {
        var category = await _categoryRepository.GetCategoryById(productDTO.CategoryId, cancellation);
        if (category == null || category.ParentId == null)
        {
            return null;
        }

        var imageEntity = new Image();

        if (productDTO.ImageDTO != null)
        {
            imageEntity.File = productDTO.ImageDTO.ImageFile;
            imageEntity.Extension = Path.GetExtension(productDTO.ImageDTO.ImageFile.FileName);
            imageEntity.SizeInBytes = productDTO.ImageDTO.ImageFile.Length;
            imageEntity.Name = productDTO.ImageDTO.Name;
            imageEntity.Description = productDTO.ImageDTO.Description;

            await _imageRepository.UploadImage(imageEntity, cancellation);
        }


        var productEntity = new Product()
        {
            Name = productDTO.Name,
            Price = productDTO.Price,
            DiscountPercentage = productDTO.DiscountPercentage,
            Description = productDTO.Description,
            GeneralImageId = (productDTO.ImageDTO != null) ? imageEntity.Id : null,
            CategoryId = productDTO.CategoryId
        };

        _productRepository.AddProduct(productEntity);
        await _productRepository.SaveChangesAsync(cancellation);


        return new AdminSideProductDTO()
        {
            Id = productEntity.Id,
            CategoryId = productEntity.CategoryId,
            Description = productEntity.Description,
            Price = productEntity.Price,
            DiscountPercentage = productEntity.DiscountPercentage,
            Name = productEntity.Name,
            GeneralImagePath = (productDTO.ImageDTO != null) ? _fileService.GetFileURL(imageEntity.Path) : null
        };
    }


    public async Task<AdminSideProductDTO?> CreateProductItem(CreateProductItemDTO productItemDTO, int productId, CancellationToken cancellation)
    {
        var product = await _productRepository.GetProductById(productId, cancellation);
        if (product == null)  return null;

        var imageEntity = new Image();

        if (productItemDTO.ImageDTO != null)
        {
            imageEntity.File = productItemDTO.ImageDTO.ImageFile;
            imageEntity.Extension = Path.GetExtension(productItemDTO.ImageDTO.ImageFile.FileName);
            imageEntity.SizeInBytes = productItemDTO.ImageDTO.ImageFile.Length;
            imageEntity.Name = productItemDTO.ImageDTO.Name;
            imageEntity.Description = productItemDTO.ImageDTO.Description;

            await _imageRepository.UploadImage(imageEntity, cancellation);
        }


        var productItemEntity = new ProductItem()
        {
            Color = productItemDTO.Color,
            Quantity = productItemDTO.Quantity,
            ImageId = (productItemDTO.ImageDTO != null) ? imageEntity.Id : null,
            ProductId = productId
        };

        _productItemRepository.AddProductItem(productItemEntity);
        await _productItemRepository.SaveChangesAsync(cancellation);


        return new AdminSideProductDTO()
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            Description = product.Description,
            Price = product.Price,
            DiscountPercentage = product.DiscountPercentage,
            Name = product.Name,
            GeneralImagePath = (productItemDTO.ImageDTO != null) ? _fileService.GetFileURL(imageEntity.Path) : null,
            ProductItems = await _productItemRepository.GetProductItemDTOsByProductId(productId, cancellation),
            ProductFeatures = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, cancellation)
        };
    }
}
