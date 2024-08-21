using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopDomain.Utilities;
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
        return await _context.Set<User>().AnyAsync(p => p.MobileNumber == mobile.Trim() && !p.IsDelete);
    }

    public bool UserExistsWithThisMobile(string mobile)
    {
        return  _context.Set<User>().Any(p => p.MobileNumber == mobile.Trim() && !p.IsDelete);
    }

    public void AddUser(User user)
    {
        _context.Set<User>().Add(user);
    }

    public void UpdateUser(User user)
    {
        _context.Set<User>().Update(user);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<User?> GetUser_By_MobileAndPassword(string mobile ,string password,CancellationToken cancellation)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(p=> p.MobileNumber==mobile && 
        p.Password == PasswordHasher.EncodePasswordMd5(password) && !p.IsDelete,cancellation);
    }

    public async Task<ICollection<UserDTO>?> GetUserDTOs(CancellationToken cancellation)
    {
        var userDTOs = await _context.Set<User>().Where(p => !p.IsDelete).Select(p => new UserDTO() 
        { Id = p.Id, CreateDate = p.CreateDate, MobileNumber = p.MobileNumber, Username = p.Username })
            .ToListAsync(cancellation);

        foreach (var userDTO in userDTOs)
        {
            userDTO.Roles = await _context.Set<UserSelectedRole>().Where(p=> p.UserId==userDTO.Id && !p.IsDelete).Select(p=>p.Role.UniqueName).ToListAsync(cancellation);
        }

        return userDTOs;
    }

    public async Task<User?> GetUserById(int userId,CancellationToken cancellation)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(p => p.Id == userId && !p.IsDelete,cancellation);
    }

    public async Task<UserDTO?> GetUserDTOById(int userId, CancellationToken cancellation)
    {
        var userDTO = await _context.Set<User>().Where(p => p.Id == userId && !p.IsDelete)
            .Select(p => new UserDTO() { Id = p.Id, CreateDate = p.CreateDate, MobileNumber = p.MobileNumber, Username = p.Username })
            .FirstOrDefaultAsync(cancellation);

        if (userDTO == null) return null;

        userDTO.Roles = await _context.Set<UserSelectedRole>().Where(p => p.UserId == userDTO.Id && !p.IsDelete)
            .Select(p => p.Role.UniqueName).ToListAsync(cancellation);

        return userDTO;
    }
}
