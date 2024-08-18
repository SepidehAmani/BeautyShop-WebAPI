using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.Entities.Image;

namespace BeautyShopApplication.Services.Interface;

public interface IImageService : IScopedDependency
{
    Task<Image> UploadImage(Image image, CancellationToken cancellation);
}
