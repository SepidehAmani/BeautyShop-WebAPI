using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.Entities.ContactUs;

namespace BeautyShopApplication.Services.Interface;

public interface IContactUsService : IScopedDependency
{
    Task<ICollection<ContactUs>?> GetListOfContactUs(CancellationToken cancellation);
    Task<ContactUs?> GetContactUsById(int id, CancellationToken cancellation);
}
