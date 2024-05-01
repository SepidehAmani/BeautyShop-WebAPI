using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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


    public async Task<ICollection<Role>?> GetListOfRoles(CancellationToken cancellation)
    {
        return await _context.Roles.Where(p=> !p.IsDelete).ToListAsync(cancellation);
    }

    public async Task<bool> AddRoleToUser(int userId, ICollection<string>? roleNames,CancellationToken cancellation)
    {
        var userExists = await _context.Users.AnyAsync(p => p.Id == userId && !p.IsDelete);
        if (!userExists) return false;

        var existingRoles = await _context.UserSelectedRoles.Where(p => p.UserId == userId && !p.IsDelete).ToListAsync(cancellation);
        if (existingRoles != null)
        {
            foreach (var role in existingRoles)
            {
                _context.Remove(role);
            }
            await _context.SaveChangesAsync(cancellation);
        }

        if (roleNames == null) return true;

        var roles = await GetListOfRoles(cancellation);
        if (roles == null) return false;

        
        
        foreach (var roleName in roleNames)
        {
            var role = roles.Where(p => p.UniqueName == roleName && !p.IsDelete).FirstOrDefault();
            if (role != null)
            {
                var userSelectedRole = new UserSelectedRole()
                {
                    RoleId = role.Id,
                    UserId = userId
                };

                _context.UserSelectedRoles.Add(userSelectedRole);
            }
            else
            { return false; }
        }
        await _context.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task DeleteUserSelectedRolesByUserId(int userId,CancellationToken cancellation)
    {
        var records = await _context.UserSelectedRoles.Where(p=> p.UserId==userId).ToListAsync(cancellation);
        if (records == null) return;

        foreach(var  record in records)
        {
            record.IsDelete = true;
            _context.Update(record);
        }
        await _context.SaveChangesAsync(cancellation);
    }
}
