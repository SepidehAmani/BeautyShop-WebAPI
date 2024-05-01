using BeautyShopDomain.Entities.User;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IRoleRepository
{
    Task<ICollection<Role>?> GetRolesByUserId(int userId, CancellationToken cancellation);
    Task<bool> AddRoleToUser(int userId, ICollection<string>? roleNames, CancellationToken cancellation);
    Task DeleteUserSelectedRolesByUserId(int userId, CancellationToken cancellation);
}
