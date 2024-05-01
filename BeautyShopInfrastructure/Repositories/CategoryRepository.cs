using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Category?> GetCategoryById(int id,CancellationToken cancellationToken)
    {
        return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id && !p.IsDelete);
    }

    public async Task<ICollection<Category>?> GetChildCategoriesByParentId(int parentId,CancellationToken cancellation)
    {
        return await _context.Categories.Where(p=> p.ParentId==parentId && !p.IsDelete).ToListAsync(cancellation);
    }
}
