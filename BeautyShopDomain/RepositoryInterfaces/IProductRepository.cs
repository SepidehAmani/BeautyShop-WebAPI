using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductRepository : IScopedDependency
{
    Task<Product?> GetProductById(int id, CancellationToken cancellation);
    Task<ICollection<ProductBoxDTO>?> GetProductBoxDTOsByCategoryIds(List<int> categoryIds, CategoryPageRequestDTO requestDTO, CancellationToken cancellation);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<bool> ProductExistsWithId(int id, CancellationToken cancellation);
    Task<ICollection<ProductBoxDTO>> GetListOfProductDTOs(string? searchString, ProductListRequestDTO requestDTO,
            CancellationToken cancellation);
}
