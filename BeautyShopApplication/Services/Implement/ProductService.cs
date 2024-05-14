using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;

namespace BeautyShopApplication.Services.Implement;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly IProductItemRepository _productItemRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IImageService _imageService;

    public ProductService(IProductRepository productRepository, IProductFeatureRepository productFeatureRepository,
        IProductItemRepository productItemRepository, ICategoryRepository categoryRepository, IImageService imageService)
    {
        _productRepository = productRepository;
        _productFeatureRepository = productFeatureRepository;
        _productItemRepository = productItemRepository;
        _categoryRepository = categoryRepository;
        _imageService = imageService;
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
            GeneralImage = product.GeneralImage!=null? product.GeneralImage.Path : null,
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

        if (productDTO.ImageDTO != null && productDTO.ImageDTO.ImageFile != null)
        {
            imageEntity.File = productDTO.ImageDTO.ImageFile;
            imageEntity.Extension = Path.GetExtension(productDTO.ImageDTO.ImageFile.FileName);
            imageEntity.SizeInBytes = productDTO.ImageDTO.ImageFile.Length;
            imageEntity.Name = productDTO.ImageDTO.Name!=null? productDTO.ImageDTO.Name : "Untitled";
            imageEntity.Description = productDTO.ImageDTO.Description;

            await _imageService.UploadImage(imageEntity, cancellation);
        }


        var productEntity = new Product()
        {
            Name = productDTO.Name,
            Price = productDTO.Price,
            DiscountPercentage = productDTO.DiscountPercentage,
            Description = productDTO.Description,
            GeneralImageId = (productDTO.ImageDTO != null && productDTO.ImageDTO.ImageFile != null) ? imageEntity.Id : null,
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
            GeneralImagePath = productEntity.GeneralImage?.Path
        };
    }


    public async Task<AdminSideProductDTO?> CreateProductItem(CreateProductItemDTO productItemDTO, int productId, CancellationToken cancellation)
    {
        var product = await _productRepository.GetProductById(productId, cancellation);
        if (product == null)  return null;

        var imageEntity = new Image();

        if (productItemDTO.ImageDTO != null && productItemDTO.ImageDTO.ImageFile != null)
        {
            imageEntity.File = productItemDTO.ImageDTO.ImageFile;
            imageEntity.Extension = Path.GetExtension(productItemDTO.ImageDTO.ImageFile.FileName);
            imageEntity.SizeInBytes = productItemDTO.ImageDTO.ImageFile.Length;
            imageEntity.Name = productItemDTO.ImageDTO.Name!=null? productItemDTO.ImageDTO.Name : "Untitled";
            imageEntity.Description = productItemDTO.ImageDTO.Description;

            await _imageService.UploadImage(imageEntity, cancellation);
        }


        var productItemEntity = new ProductItem()
        {
            Color = productItemDTO.Color,
            Quantity = productItemDTO.Quantity,
            ImageId = (productItemDTO.ImageDTO != null && productItemDTO.ImageDTO.ImageFile != null) ? imageEntity.Id : null,
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
            GeneralImagePath = product.GeneralImage?.Path,
            ProductItems = await _productItemRepository.GetProductItemDTOsByProductId(productId, cancellation),
            ProductFeatures = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, cancellation)
        };
    }


    public async Task<AdminSideProductDTO?> CreateProductFeature(CreateProductFeatureDTO featureDTO,int productId,CancellationToken cancellation)
    {
        var product = await _productRepository.GetProductById(productId, cancellation);
        if (product == null) return null;

        var productFeatureEntity = new ProductFeature()
        {
            Title= featureDTO.Title,
            Description = featureDTO.Description,
            ProductId = productId
        };

        _productFeatureRepository.AddProductFeature(productFeatureEntity);
        await _productFeatureRepository.SaveChangesAsync(cancellation);


        return new AdminSideProductDTO()
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            Description = product.Description,
            Price = product.Price,
            DiscountPercentage = product.DiscountPercentage,
            Name = product.Name,
            GeneralImagePath = (product.GeneralImage != null) ? product.GeneralImage.Path : null,
            ProductItems = await _productItemRepository.GetProductItemDTOsByProductId(productId, cancellation),
            ProductFeatures = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, cancellation)
        };
    }



    public async Task<ICollection<ProductBoxDTO>> GetListOfProductDTOs(string? searchString, ProductListRequestDTO requestDTO,
            CancellationToken cancellation)
    {
        return await _productRepository.GetListOfProductDTOs(searchString,requestDTO, cancellation);
    }
}
