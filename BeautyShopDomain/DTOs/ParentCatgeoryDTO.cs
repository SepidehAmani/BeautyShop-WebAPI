using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.DTOs;

public class ParentCatgeoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ChildCategoryDTO>? ChildCategories { get; set; }
}
