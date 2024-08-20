using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopDomain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BeautyShopApplication.Services.Implement;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IConfiguration _configuration;
    public AccountService(IUserRepository userRepository,IRoleRepository roleRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _configuration = configuration;
    }


    public async Task<bool> RegisterUser (RegisterUserDTO userDTO, CancellationToken cancellation)
    {
        var userExists = await _userRepository.UserExistsWithThisMobile(userDTO.MobileNumber, cancellation);
        if (userExists) return false;

        var user = new User()
        {
            Username = userDTO.UserName,
            MobileNumber = userDTO.MobileNumber.Trim(),
            Password = PasswordHasher.EncodePasswordMd5(userDTO.Password)
        };

        _userRepository.AddUser(user);
        await _userRepository.SaveChangesAsync(cancellation);

        return true;
    }


    public async Task<LoginUserResponse> LoginUser(LoginUserDTO userDTO, CancellationToken cancellation)
    {
        var user = await _userRepository.GetUser_By_MobileAndPassword(userDTO.MobileNumber,userDTO.Password, cancellation);
        if (user == null) return new LoginUserResponse(false, "");

        var roles = await _roleRepository.GetRolesByUserId(user.Id, cancellation);
        var token = GetToken(user,roles);

        return new LoginUserResponse(true, token);
    }


    string GetToken(User user , ICollection<Role>? roles)
    {
        var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
                );
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claimsForToken.Add(new Claim(ClaimTypes.Name, user.Username));
        claimsForToken.Add(new Claim(ClaimTypes.MobilePhone, user.MobileNumber));

        if(roles != null)
        {
            foreach (var role in roles)
            {
                claimsForToken.Add(new Claim(ClaimTypes.Role, role.UniqueName));
            }
        }
        

        var jwtSecurityToke = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.Now,
            DateTime.Now.AddHours(1),
            signingCredentials
            );

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToke);
        return tokenToReturn;
    }
}
