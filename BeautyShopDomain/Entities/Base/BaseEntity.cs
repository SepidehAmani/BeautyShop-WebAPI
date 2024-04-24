namespace BeautyShopDomain.Entities.Base;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
