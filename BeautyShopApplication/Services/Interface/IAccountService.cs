using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.User;

namespace BeautyShopApplication.Services.Interface;

public interface IAccountService
{
    Task<RegisterUserResponse> RegisterUser(RegisterUserDTO userDTO, CancellationToken cancellation);
    Task<LoginUserResponse> LoginUser(LoginUserDTO userDTO, CancellationToken cancellation);
}
