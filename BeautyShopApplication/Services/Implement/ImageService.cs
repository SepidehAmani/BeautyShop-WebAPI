using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace BeautyShopApplication.Services.Implement;

public class ImageService : IImageService
{

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IImageRepository _imageRepository;

    public ImageService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor,
        IImageRepository imageRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _imageRepository = imageRepository;
    }


    public async Task<Image> UploadImage(Image image, CancellationToken cancellation)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
            $"{image.Name}{image.Extension}");

        using var stream = new FileStream(filePath, FileMode.Create);
        await image.File.CopyToAsync(stream);

        var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.Name}{image.Extension}";

        image.Path = urlFilePath;

        _imageRepository.AddImage(image);
        await _imageRepository.SaveChangesAsync(cancellation);

        return image;
    }
}
