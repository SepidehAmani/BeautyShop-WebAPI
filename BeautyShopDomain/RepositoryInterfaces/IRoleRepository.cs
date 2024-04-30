using BeautyShopDomain.Entities.User;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IRoleRepository
{
    Task<ICollection<Role>?> GetRolesByUserId(int userId, CancellationToken cancellation);
}
