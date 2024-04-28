using BeautyShopApplication.Utilities;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExistsWithThisMobile(string mobile,CancellationToken cancellation)
    {
        return await _context.Users.AnyAsync(p => p.MobileNumber == mobile.Trim() && !p.IsDelete);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<User?> GetUser_By_MobileAndPassword(string mobile ,string password,CancellationToken cancellation)
    {
        return await _context.Users.FirstOrDefaultAsync(p=> p.MobileNumber==mobile && 
        p.Password == PasswordHasher.EncodePasswordMd5(password) && !p.IsDelete,cancellation);
    }
}
