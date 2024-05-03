using BeautyShopApplication.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace BeautyShopApplication.Services.Implement;

public class FileService : IFileService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public FileService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    public string GetFileURL(string filePath)
    {
        return $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}{filePath}";
    }
}
