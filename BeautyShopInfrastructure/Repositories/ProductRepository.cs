using BeautyShopDomain.DTOs;
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

    public async Task<ICollection<ProductBoxDTO>?> GetProductBoxDTOsByCategoryIds(List<int> categoryIds,CategoryPageRequestDTO requestDTO,CancellationToken cancellation)
    {
        var products = _context.Products.Where(p => categoryIds.Contains(p.CategoryId) && !p.IsDelete).AsQueryable();

        switch (requestDTO.Order)
        {
            case "Newest":
                products = products.OrderByDescending(p => p.Id).AsQueryable();
                break;
            case "Cheapest":
                products = products.OrderBy(p=> p.Price).AsQueryable();
                break;
            case "MostExpensive":
                products = products.OrderByDescending(p => p.Price).AsQueryable();
                break;
            default:
                break;
        }

        return await products.Skip((requestDTO.PageNumber - 1) * requestDTO.PageSize)
            .Take(requestDTO.PageSize)
            .Select(p => new ProductBoxDTO() { Id = p.Id, Name = p.Name, Price = p.Price, DiscountPercentage = p.DiscountPercentage, GeneralImage = p.GeneralImage })
            .ToListAsync(cancellation);
    }
}
