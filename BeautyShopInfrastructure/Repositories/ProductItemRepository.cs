using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class ProductItemRepository : IProductItemRepository
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ProductItemRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ICollection<ProductItemDTO>?> GetProductItemDTOsByProductId(int productId,CancellationToken cancellation)
    {
        return await _context.ProductItems.Where(p => p.ProductId == productId && !p.IsDelete)
            .Select(p => new ProductItemDTO() { Id = p.Id, Color = p.Color, ImageURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}{p.Image.Path}", Quantity = p.Quantity })
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
