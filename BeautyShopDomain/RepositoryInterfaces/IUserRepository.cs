using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.User;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IUserRepository
{
    Task<bool> UserExistsWithThisMobile(string mobile, CancellationToken cancellation);
    void AddUser(User user);
    void UpdateUser(User user);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<User?> GetUser_By_MobileAndPassword(string mobile, string password, CancellationToken cancellation);
    Task<ICollection<UserDTO>?> GetUserDTOs(CancellationToken cancellation);
    Task<User?> GetUserById(int userId, CancellationToken cancellation);
    Task<UserDTO?> GetUserDTOById(int userId, CancellationToken cancellation);
}
