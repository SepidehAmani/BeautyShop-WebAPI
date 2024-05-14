using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<ICollection<ParentCatgeoryDTO>?> GetListOfCategoryDTOs(CancellationToken cancellation)
    {
        var parentCategories = await _context.Categories.Where(p => !p.IsDelete && p.ParentId == null)
            .Select(p=> new ParentCatgeoryDTO() { Id=p.Id,Name=p.Name}).ToListAsync(cancellation);

        if (parentCategories!=null && parentCategories.Any())
        {
            foreach(var item in  parentCategories)
            {
                item.ChildCategories = await _context.Categories.Where(p => p.ParentId == item.Id && !p.IsDelete)
                    .Select(p=> new ChildCategoryDTO() { Id=p.Id,ParentId=item.Id,Name=p.Name})
                    .ToListAsync(cancellation);
            }
        }

        return parentCategories;
    }
}
