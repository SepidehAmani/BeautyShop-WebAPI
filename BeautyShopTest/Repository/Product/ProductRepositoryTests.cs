using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;
using BeautyShopInfrastructure.DBContext;
using BeautyShopInfrastructure.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopTest.Repository.Product;

public class ProductRepositoryTests
{
    private async Task<AppDbContext> GetDBContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        var dbContext = new AppDbContext(options);

        dbContext.Database.EnsureCreated();

        if (! await dbContext.Products.AnyAsync(p=> p.Id==1))
        {
            dbContext.Categories.Add(new Category() { Id = 1, Name = "Test1" });
            dbContext.Categories.Add(new Category() { Id = 2, Name = "Test2", ParentId = 1 });

            dbContext.Products.Add(
                new BeautyShopDomain.Entities.Product.Product() { Id = 1,Name = "Test",CategoryId=2,Price=1000,DiscountPercentage=0}
                );

            for (int i = 1; i <= 2; i++)
            {
                dbContext.ProductItems.Add(
                new ProductItem() { ProductId=1,Quantity=2, Color="red"}
                );
            }

            for (int i = 1; i <= 2; i++)
            {
                dbContext.ProductFeatures.Add(
                new ProductFeature() { ProductId=1,Title="Test",Description="Test"}
                );
            }
        }
        await dbContext.SaveChangesAsync();
        return dbContext;
    }


    [Fact]
    public async Task ProductRepository_GetProductById_RerturnsProduct()
    {
        //Arrange
        int id = 1;
        var _context = await GetDBContext();
        var _productRepository = new ProductRepository(_context);

        //Act
        var result = await _productRepository.GetProductById(id, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(BeautyShopDomain.Entities.Product.Product));
    }


    [Fact]
    public async Task ProductRepository_GetProductBoxDTOsByCategoryIds_ReturnsListOfProductBoxDTO()
    {
        //Arrange
        List<int> categoryIds = new List<int>() { 2};
        var requestDTO = A.Fake<CategoryPageRequestDTO>();
        var _context = await GetDBContext();
        var _productRepository = new ProductRepository(_context);

        //Act
        var result = await _productRepository.GetProductBoxDTOsByCategoryIds(categoryIds,requestDTO,CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(List<ProductBoxDTO>));
    }

    [Fact]
    public async Task ProductRepository_ProductExistsWithId_ReturnsBool()
    {
        //Arrange
        int id = 1;
        var _context = await GetDBContext();
        var _productRepository = new ProductRepository(_context);

        //Act
        var result = await _productRepository.ProductExistsWithId(id, CancellationToken.None);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ProductRepository_GetListOfProductDTOs_ReturnsListOfProductBoxDTO()
    {
        //Arrange
        string searchString = "";
        var requestDTO = A.Fake<ProductListRequestDTO>();
        var _context = await GetDBContext();
        var _productRepository = new ProductRepository(_context);

        //Act
        var result = await _productRepository.GetListOfProductDTOs(searchString, requestDTO, CancellationToken.None);

        //Assert
        result.Should().BeOfType(typeof(List<ProductBoxDTO>));
    }
}
