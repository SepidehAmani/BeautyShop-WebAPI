using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopWebAPI.Controllers.AdminSide;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopTest.Controller.Product;

public class AdminSideProductControllerTests
{
    private readonly IProductService _productService;
    private readonly ProductController _productController;
    public AdminSideProductControllerTests()
    {
        _productService = A.Fake<IProductService>();
        _productController = new ProductController(_productService);
    }


    [Fact]
    public async Task AdminSideProductController_CreateProduct_ReturnsAdminSideProductDTO()
    {
        //Arrange
        var dto = A.Fake<CreateProductDTO>();
        A.CallTo(() => _productService.ValidateImageFile(dto.ImageDTO)).Returns(true);
        A.CallTo(() => _productService.CreateProduct(dto, CancellationToken.None)).Returns(A.Fake<AdminSideProductDTO>());

        //Act
        var result = await _productController.CreateProduct(dto, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(OkObjectResult));
    }


    [Fact]
    public async Task AdminSideProductController_CreateProductItem_ReturnsAdminSideProductDTO()
    {
        //Arrange
        int productId = 1;
        var dto = A.Fake<CreateProductItemDTO>();
        A.CallTo(() => _productService.ValidateImageFile(dto.ImageDTO)).Returns(true);
        A.CallTo(() => _productService.CreateProductItem(dto,productId, CancellationToken.None)).Returns(A.Fake<AdminSideProductDTO>());

        //Act
        var result = await _productController.CreateProductItem(dto,productId, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(OkObjectResult));
    }


    [Fact]
    public async Task AdminSideProductController_CreateProductFeature_ReturnsAdminSideProductDTO()
    {
        //Arrange
        int productId = 1;
        var dto = A.Fake<CreateProductFeatureDTO>();
        A.CallTo(() => _productService.CreateProductFeature(dto, productId, CancellationToken.None)).Returns(A.Fake<AdminSideProductDTO>());

        //Act
        var result = await _productController.CreateProductFeature(dto, productId, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}
