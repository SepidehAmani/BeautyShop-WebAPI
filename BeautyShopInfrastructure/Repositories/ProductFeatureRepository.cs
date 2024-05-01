using BeautyShopDomain.DTOs;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class ProductFeatureRepository : IProductFeatureRepository
{
    private readonly AppDbContext _context;
    public ProductFeatureRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<ICollection<ProductFeatureDTO>?> GetProductFeatureDTOsByProductId(int productId,CancellationToken cancellation)
    {
        return await _context.ProductFeatures.Where(p => p.ProductId == productId)
            .Select(p => new ProductFeatureDTO() { Title = p.Title, Description = p.Description })
            .ToListAsync(cancellation);
    }
}
