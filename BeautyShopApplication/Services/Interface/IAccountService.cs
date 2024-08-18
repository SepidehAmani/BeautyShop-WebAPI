using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.User;

namespace BeautyShopApplication.Services.Interface;

public interface IAccountService : IScopedDependency
{
    Task<bool> RegisterUser(RegisterUserDTO userDTO, CancellationToken cancellation);
    Task<LoginUserResponse> LoginUser(LoginUserDTO userDTO, CancellationToken cancellation);
}