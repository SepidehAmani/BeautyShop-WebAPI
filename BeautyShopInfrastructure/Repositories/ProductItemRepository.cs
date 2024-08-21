using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class ProductItemRepository : IProductItemRepository
{
    private readonly AppDbContext _context;
    public ProductItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ProductItemDTO>?> GetProductItemDTOsByProductId(int productId,CancellationToken cancellation)
    {
        return await _context.Set<ProductItem>().Where(p => p.ProductId == productId && !p.IsDelete)
            .Select(p => new ProductItemDTO() { Id = p.Id, Color = p.Color, ImagePath = p.Image.Path, Quantity = p.Quantity })
            .ToListAsync(cancellation);
    }

    public async Task<ICollection<ProductItem>?> GetProductItemsByProductId(int productId,CancellationToken cancellation)
    {
        return await _context.Set<ProductItem>().Where(p => p.ProductId == productId && !p.IsDelete).ToListAsync(cancellation);
    }

    public void AddProductItem(ProductItem item)
    {
        _context.Set<ProductItem>().Add(item);
    }

    public void UpdateProductItem(ProductItem item)
    {
        _context.Set<ProductItem>().Update(item);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }


    public async Task<bool> ProductItemExistsWithId(int productItemId,CancellationToken cancellation)
    {
        return await _context.Set<ProductItem>().AnyAsync(p => p.Id == productItemId && !p.IsDelete);
    }

    public async Task<ProductItem?> GetProductItemById(int id,CancellationToken cancellation)
    {
        return await _context.Set<ProductItem>().Where(p => p.Id == id && !p.IsDelete).FirstOrDefaultAsync(cancellation);
    }

    public async Task<ProductItem?> GetProductItemWithProductById(int id, CancellationToken cancellation)
    {
        return await _context.Set<ProductItem>().Where(p => p.Id == id && !p.IsDelete).Include(p=> p.Product).FirstOrDefaultAsync(cancellation);
    }
}
