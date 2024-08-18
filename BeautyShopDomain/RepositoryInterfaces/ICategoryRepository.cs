using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface ICategoryRepository : IScopedDependency
{
    Task<Category?> GetCategoryById(int id, CancellationToken cancellationToken);
    Task<ICollection<Category>?> GetChildCategoriesByParentId(int parentId, CancellationToken cancellation);
    Task<ICollection<ParentCatgeoryDTO>?> GetListOfCategoryDTOs(CancellationToken cancellation);
}
