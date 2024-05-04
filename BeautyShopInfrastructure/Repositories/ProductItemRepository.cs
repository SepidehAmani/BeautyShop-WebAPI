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
        return await _context.ProductItems.Where(p => p.ProductId == productId && !p.IsDelete)
            .Select(p => new ProductItemDTO() { Id = p.Id, Color = p.Color, ImagePath = p.Image.Path, Quantity = p.Quantity })
            .ToListAsync(cancellation);
    }

    public async Task<ICollection<ProductItem>?> GetProductItemsByProductId(int productId,CancellationToken cancellation)
    {
        return await _context.ProductItems.Where(p => p.ProductId == productId && !p.IsDelete).ToListAsync(cancellation);
    }

    public void AddProductItem(ProductItem item)
    {
        _context.ProductItems.Add(item);
    }

    public void UpdateProductItem(ProductItem item)
    {
        _context.ProductItems.Update(item);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }
}
