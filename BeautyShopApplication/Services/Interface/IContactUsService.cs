using BeautyShopDomain.Entities.ContactUs;

namespace BeautyShopApplication.Services.Interface;

public interface IContactUsService
{
    Task<ICollection<ContactUs>?> GetListOfContactUs(CancellationToken cancellation);
    Task<ContactUs?> GetContactUsById(int id, CancellationToken cancellation);
}
