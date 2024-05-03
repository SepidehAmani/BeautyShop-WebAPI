using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ProductRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<Product?> GetProductById(int id,CancellationToken cancellation)
    {
        return await _context.Products.Where(p => p.Id == id && !p.IsDelete).Include(p=> p.GeneralImage).FirstOrDefaultAsync(cancellation);
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
            .Select(p => new ProductBoxDTO() { Id = p.Id, Name = p.Name, Price = p.Price, DiscountPercentage = p.DiscountPercentage, GeneralImageURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}{p.GeneralImage.Path}" })
            .ToListAsync(cancellation);
    }


    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<bool> ProductExistsWithId(int id,CancellationToken cancellation)
    {
        return await _context.Products.AnyAsync(p => p.Id == id && !p.IsDelete);
    }
}
