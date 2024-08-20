using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;

namespace BeautyShopInfrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;

    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }


    public void AddImage(Image image)
    {
        _context.Set<Image>().Add(image);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    
}
