using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace BeautyShopInfrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public ImageRepository(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor,
        AppDbContext context)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }


    public async Task<Image> UploadImage(Image image,CancellationToken cancellation)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
            $"{image.Name}{image.Extension}");

        using var stream = new FileStream(filePath, FileMode.Create);
        await image.File.CopyToAsync(stream);

        var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.Name}{image.Extension}";

        image.Path = urlFilePath;

        _context.Images.Add(image);
        await _context.SaveChangesAsync(cancellation);

        return image;
    }
}
