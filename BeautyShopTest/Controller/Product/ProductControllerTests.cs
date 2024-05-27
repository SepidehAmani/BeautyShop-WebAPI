using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopWebAPI.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopTest.Controller.Product;

public class ProductControllerTests
{
    private readonly IProductService _productService;
    private readonly ProductController _productController;
    public ProductControllerTests()
    {
        _productService = A.Fake<IProductService>();
        _productController = new ProductController(_productService);
    }

    [Fact]
    public async Task ProductController_GetProduct_ReturnsProduct()
    {
        //Arrange
        int productId = 1;
        ProductPageDTO product = A.Fake<ProductPageDTO>();
        A.CallTo(() => _productService.GetProductPageDTO(productId,CancellationToken.None)).Returns(product);

        //Act
        var result = await _productController.GetProduct(productId);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("Test")]
    public async Task ProductController_GetListOfProducts_ReturnsListOfProducts(string? searchString)
    {
        //Arrange
        ProductListRequestDTO productListRequestDTO = A.Fake<ProductListRequestDTO>();
        ICollection<ProductBoxDTO> productListDTO = A.Fake<ICollection<ProductBoxDTO>>();
        A.CallTo(() => _productService.GetListOfProductDTOs(searchString, productListRequestDTO, CancellationToken.None))
            .Returns(productListDTO);

        //Act
        var result = await _productController.GetListOfProducts(searchString, productListRequestDTO, CancellationToken.None);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

    }


}
