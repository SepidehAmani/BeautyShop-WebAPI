using BeautyShopDomain.DTOs.AdminSide;
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


    public async Task<ICollection<RoleDTO>?> GetListOfRolDTOs(CancellationToken cancellation)
    {
        return await _context.Roles.Where(p => !p.IsDelete)
            .Select(p => new RoleDTO() { Id = p.Id, CreateDate = p.CreateDate, UniqueName = p.UniqueName })
            .ToListAsync(cancellation);
    }

    public async Task<RoleDTO?> GetRoleDTOByRoleId(int roleId,CancellationToken cancellation)
    {
        return await _context.Roles.Where(p => p.Id == roleId && !p.IsDelete)
            .Select(p => new RoleDTO() { Id = p.Id, CreateDate = p.CreateDate, UniqueName = p.UniqueName })
            .FirstOrDefaultAsync(cancellation);
    }


    public async Task<bool> RoleExistsWithName(string name,CancellationToken cancellation)
    {
        return await _context.Roles.AnyAsync(p=> p.UniqueName.ToLower() == name.ToLower() && !p.IsDelete , cancellation);
    }

    public void AddRole(Role role)
    {
        _context.Roles.Add(role);
    }

    public void UpdateRole(Role role)
    {
        _context.Roles.Update(role);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<bool> RoleExistsWithName_ForEditRole(int roleId ,string name, CancellationToken cancellation)
    {
        return await _context.Roles.AnyAsync(p => p.Id != roleId && p.UniqueName.ToLower() == name.ToLower() && !p.IsDelete, cancellation);
    }

    public async Task<Role?> GetRoleById(int roleId,CancellationToken cancellation)
    {
        return await _context.Roles.FirstOrDefaultAsync(p => p.Id == roleId && !p.IsDelete);
    }
}
