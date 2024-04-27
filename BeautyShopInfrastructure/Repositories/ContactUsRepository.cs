using BeautyShopDomain.Entities.ContactUs;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly AppDbContext _context;
        public ContactUsRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ICollection<ContactUs>?> GetListOfContactUs(CancellationToken cancellation)
        {
            return await _context.ContactUs.ToListAsync(cancellation);
        }

        public async Task<ContactUs?> GetContactUsById(int id, CancellationToken cancellation)
        {
            return await _context.ContactUs.FindAsync(id, cancellation);
        }

        public void AddContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
        }

        public void UpdateContactUs(ContactUs contactUs) 
        {
            _context.ContactUs.Update(contactUs);
        }

        public void DeleteContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Remove(contactUs);
        }

        public async Task SaveChangesAsync(CancellationToken cancellation)
        {
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
