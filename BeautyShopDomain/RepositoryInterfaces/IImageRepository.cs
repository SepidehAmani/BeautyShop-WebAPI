using BeautyShopDomain.Entities.Image;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IImageRepository
{
    void AddImage(Image image);
    Task SaveChangesAsync(CancellationToken cancellation);
}
