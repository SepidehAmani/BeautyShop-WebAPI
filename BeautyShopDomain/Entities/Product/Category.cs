using BeautyShopDomain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyShopDomain.Entities.Product;

public class Category : BaseEntity
{
    public int? ParentId { get; set; }
    public string Name { get; set; }
    public bool IsDelete { get; set; }


    public ICollection<Product>? Products { get; set; }
}
