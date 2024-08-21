using BeautyShopDomain.Entities.Base;

namespace BeautyShopDomain.Entities.ContactUs;

public class ContactUs : BaseEntity , IEntity
{
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Text { get; set; }
    public bool IsSeen { get; set; }
}
