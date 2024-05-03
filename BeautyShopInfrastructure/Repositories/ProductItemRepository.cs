using BeautyShopDomain.DTOs;
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
            .Select(p => new ProductItemDTO() { Id = p.Id, Color = p.Color, Image = p.Image.Path, Quantity = p.Quantity })
            .ToListAsync(cancellation);
    }
}
