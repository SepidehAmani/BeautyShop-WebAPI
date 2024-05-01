using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryById(int id, CancellationToken cancellationToken);
    Task<ICollection<Category>?> GetChildCategoriesByParentId(int parentId, CancellationToken cancellation);
}
