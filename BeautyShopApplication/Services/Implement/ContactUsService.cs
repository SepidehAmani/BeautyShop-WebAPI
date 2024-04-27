using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.Entities.ContactUs;
using BeautyShopDomain.RepositoryInterfaces;

namespace BeautyShopApplication.Services.Implement;

public class ContactUsService : IContactUsService
{
    private readonly IContactUsRepository _contactUsRepository;
    public ContactUsService(IContactUsRepository contactUsRepository)
    {
        _contactUsRepository = contactUsRepository;
    }

    public async Task<ICollection<ContactUs>?> GetListOfContactUs(CancellationToken cancellation)
    {
        return await _contactUsRepository.GetListOfContactUs(cancellation);
    }

    public async Task<ContactUs?> GetContactUsById(int id, CancellationToken cancellation)
    {
        return await _contactUsRepository.GetContactUsById(id, cancellation);
    }

    
}
