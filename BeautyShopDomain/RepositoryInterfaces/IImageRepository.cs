using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.Entities.Image;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IImageRepository : IScopedDependency
{
    void AddImage(Image image);
    Task SaveChangesAsync(CancellationToken cancellation);
}
