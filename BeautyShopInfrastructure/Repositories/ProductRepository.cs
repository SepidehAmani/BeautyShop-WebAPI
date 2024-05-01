using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Product?> GetProductById(int id,CancellationToken cancellation)
    {
        return await _context.Products.Where(p => p.Id == id && !p.IsDelete).FirstOrDefaultAsync(cancellation);
    }
}
