using BeautyShopDomain.Entities.Image;

namespace BeautyShopApplication.Services.Interface;

public interface IImageService
{
    Task<Image> UploadImage(Image image, CancellationToken cancellation);
}
