using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs.AdminSide;

namespace BeautyShopApplication.Services.Interface;

public interface IUserService : IScopedDependency
{
    Task<ICollection<UserDTO>?> GetListOfUsers(CancellationToken cancellation);
    Task<UserDTO?> GetUserDTOById(int userId, CancellationToken cancellation);
    Task<bool> EditUser(int userId, EditUserDTO userDTO, CancellationToken cancellation);
    Task<bool> DeleteUser(int userId, CancellationToken cancellation);
}
