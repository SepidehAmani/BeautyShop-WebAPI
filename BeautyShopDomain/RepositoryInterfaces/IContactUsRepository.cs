using BeautyShopDomain.Entities.ContactUs;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IContactUsRepository
{
    Task<ICollection<ContactUs>?> GetListOfContactUs(CancellationToken cancellation);
    Task<ContactUs?> GetContactUsById(int id, CancellationToken cancellation);
    void AddContactUs(ContactUs contactUs);
    void UpdateContactUs(ContactUs contactUs);
    void DeleteContactUs(ContactUs contactUs);
    Task SaveChangesAsync(CancellationToken cancellation);
}
