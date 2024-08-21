using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyShopDomain.Entities.Image;

public class Image : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Extension { get; set; }
    public long SizeInBytes { get; set; }
    public string Path { get; set; }

    [NotMapped]
    public IFormFile File { get; set; }
}
