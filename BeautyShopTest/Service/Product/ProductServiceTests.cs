using BeautyShopApplication.Services.Implement;
using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using FakeItEasy;
using FluentAssertions;

namespace BeautyShopTest.Service.Product;

public class ProductServiceTests
{
    private readonly IProductRepository _productRepository;
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly IProductItemRepository _productItemRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IImageService _imageService;
    private readonly IProductService _productService;
    public ProductServiceTests()
    {
        _categoryRepository = A.Fake<ICategoryRepository>();
        _imageService = A.Fake<IImageService>();
        _productFeatureRepository = A.Fake<IProductFeatureRepository>();
        _productItemRepository = A.Fake<IProductItemRepository>();
        _productRepository = A.Fake<IProductRepository>();
        _productService = new ProductService(_productRepository,_productFeatureRepository,_productItemRepository,_categoryRepository,_imageService);
    }


    [Fact]
    public async Task ProductService_GetProductPageDTO_ReturnsProductPageDTO()
    {
        //Arrange
        int productId = 1;
        var product = A.Fake<BeautyShopDomain.Entities.Product.Product>();
        A.CallTo(() => _productRepository.GetProductById(productId, CancellationToken.None)).Returns(product);
        A.CallTo(()=> _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, CancellationToken.None))
            .Returns(A.Fake<ICollection<ProductFeatureDTO>>());
        A.CallTo(() => _productItemRepository.GetProductItemDTOsByProductId(productId, CancellationToken.None))
            .Returns(A.Fake<ICollection<ProductItemDTO>>());

        //Act
        var result = await _productService.GetProductPageDTO(productId, CancellationToken.None);

        //Arrange
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(ProductPageDTO));
    }


    [Fact]
    public async Task ProductService_CreateProduct_ReturnsAdminSideProductDTO()
    {
        //Arrange
        var productDTO = A.Fake<CreateProductDTO>();
        var product = A.Fake<BeautyShopDomain.Entities.Product.Product>();
        A.CallTo(() => _categoryRepository.GetCategoryById(productDTO.CategoryId, CancellationToken.None)).Returns(new Category() { Id=2,Name="Test",ParentId=1});
        A.CallTo(() => _productRepository.AddProduct(product));
        A.CallTo(() => _productRepository.SaveChangesAsync(CancellationToken.None));

        //Act
        var result = await _productService.CreateProduct(productDTO,CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(AdminSideProductDTO));
    }


    [Fact]
    public async Task ProductService_CreateProductItem_ReturnsAdminSideProductDTO()
    {
        //Arrange
        var dto = A.Fake<CreateProductItemDTO>();
        var product = A.Fake<BeautyShopDomain.Entities.Product.Product>();
        var productItem = A.Fake<ProductItem>();
        A.CallTo(() => _productRepository.GetProductById(product.Id, CancellationToken.None)).Returns(product);
        A.CallTo(() => _productItemRepository.AddProductItem(productItem));
        A.CallTo(() => _productItemRepository.SaveChangesAsync(CancellationToken.None));
        A.CallTo(() => _productItemRepository.GetProductItemDTOsByProductId(product.Id, CancellationToken.None)).Returns(A.Fake<ICollection<ProductItemDTO>>());
        A.CallTo(() => _productFeatureRepository.GetProductFeatureDTOsByProductId(product.Id, CancellationToken.None)).Returns(A.Fake<ICollection<ProductFeatureDTO>>());

        //Act
        var result = await _productService.CreateProductItem(dto,product.Id, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(AdminSideProductDTO));
    }


    [Fact]
    public async Task ProductService_CreateProductFeature_ReturnsAdminSideProductDTO()
    {
        //Arrange
        var dto = A.Fake<CreateProductFeatureDTO>();
        var product = A.Fake<BeautyShopDomain.Entities.Product.Product>();
        var productFeature = A.Fake<ProductFeature>();
        A.CallTo(() => _productRepository.GetProductById(product.Id, CancellationToken.None)).Returns(product);
        A.CallTo(() => _productFeatureRepository.AddProductFeature(productFeature));
        A.CallTo(() => _productFeatureRepository.SaveChangesAsync(CancellationToken.None));
        A.CallTo(() => _productItemRepository.GetProductItemDTOsByProductId(product.Id, CancellationToken.None))
            .Returns(A.Fake<ICollection<ProductItemDTO>>());
        A.CallTo(() => _productFeatureRepository.GetProductFeatureDTOsByProductId(product.Id, CancellationToken.None))
            .Returns(A.Fake<ICollection<ProductFeatureDTO>>());

        //Act
        var result = await _productService.CreateProductFeature(dto, product.Id, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(AdminSideProductDTO));
    }
}
