using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;
    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<ICollection<Role>?> GetRolesByUserId(int userId,CancellationToken cancellation)
    {
        return await _context.UserSelectedRoles.Where(p => p.UserId == userId && !p.IsDelete)
            .Select(p => p.Role).ToListAsync(cancellation);
    }
}
