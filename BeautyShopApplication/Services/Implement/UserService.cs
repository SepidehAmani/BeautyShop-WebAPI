using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Exceptions;
using BeautyShopDomain.RepositoryInterfaces;

namespace BeautyShopApplication.Services.Implement;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserService(IUserRepository userRepository,IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }


    public async Task<ICollection<UserDTO>?> GetListOfUsers(CancellationToken cancellation)
    {
        return await _userRepository.GetUserDTOs(cancellation);
    }


    public async Task<UserDTO?> GetUserDTOById(int userId,CancellationToken cancellation)
    {
        return await _userRepository.GetUserDTOById(userId,cancellation);
    }

    public async Task<bool> EditUser(int userId,EditUserDTO userDTO,CancellationToken cancellation)
    {
        var user = await _userRepository.GetUserById(userId, cancellation);
        if (user == null) throw new UserNotFoundException("User not Found");


        user.SetMobile(userDTO.MobileNumber,_userRepository);

        user.Username = userDTO.Username;

        _userRepository.UpdateUser(user);
        await _userRepository.SaveChangesAsync(cancellation);

        var res = await _roleRepository.AddRoleToUser(userId, userDTO.Roles, cancellation);
        if (!res) return false;

        return true;
    }


    public async Task<bool> DeleteUser(int userId,CancellationToken cancellation)
    {
        var user = await _userRepository.GetUserById(userId, cancellation);
        if (user == null) return false;

        user.IsDelete=true;
        _userRepository.UpdateUser(user);

        await _roleRepository.DeleteUserSelectedRolesByUserId(userId, cancellation);
        return true;
    }
}
