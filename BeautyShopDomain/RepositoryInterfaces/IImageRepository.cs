using BeautyShopDomain.Entities.Image;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IImageRepository
{
    Task<Image> UploadImage(Image image, CancellationToken cancellation);
}
