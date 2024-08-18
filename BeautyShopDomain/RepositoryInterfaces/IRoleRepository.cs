using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.User;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IRoleRepository : IScopedDependency
{
    Task<ICollection<Role>?> GetRolesByUserId(int userId, CancellationToken cancellation);
    Task<bool> AddRoleToUser(int userId, ICollection<string>? roleNames, CancellationToken cancellation);
    Task DeleteUserSelectedRolesByUserId(int userId, CancellationToken cancellation);
    Task<ICollection<RoleDTO>?> GetListOfRolDTOs(CancellationToken cancellation);
    Task<RoleDTO?> GetRoleDTOByRoleId(int roleId, CancellationToken cancellation);
    Task<bool> RoleExistsWithName(string name, CancellationToken cancellation);
    void AddRole(Role role);
    void UpdateRole(Role role);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<bool> RoleExistsWithName_ForEditRole(int roleId, string name, CancellationToken cancellation);
    Task<Role?> GetRoleById(int roleId, CancellationToken cancellation);
}
