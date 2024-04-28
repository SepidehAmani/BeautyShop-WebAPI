using BeautyShopApplication.Services.Interface;
using BeautyShopApplication.Utilities;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BeautyShopApplication.Services.Implement;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    public AccountService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }


    public async Task<RegisterUserResponse> RegisterUser (RegisterUserDTO userDTO, CancellationToken cancellation)
    {
        var userExists = await _userRepository.UserExistsWithThisMobile(userDTO.Mobile,cancellation);
        if (userExists) return new RegisterUserResponse(false, "There is already a user with this MobileNumber");

        User user = new()
        { MobileNumber = userDTO.Mobile,Username = userDTO.UserName,
            Password=PasswordHasher.EncodePasswordMd5(userDTO.Password)
        };

        _userRepository.AddUser(user);
        await _userRepository.SaveChangesAsync(cancellation);

        return new RegisterUserResponse(true, "New User Added Successfully");
    }


    public async Task<LoginUserResponse> LoginUser(LoginUserDTO userDTO, CancellationToken cancellation)
    {
        var user = await _userRepository.GetUser_By_MobileAndPassword(userDTO.Mobile,userDTO.Password,cancellation);
        if (user == null) return new LoginUserResponse(false, "There is no User with this Info", "");

        var token = GetToken(user);

        return new LoginUserResponse(true, "Login was Successful", token);
    }


    string GetToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
                );
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256
            );

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claimsForToken.Add(new Claim(ClaimTypes.Name, user.Username));
        claimsForToken.Add(new Claim(ClaimTypes.MobilePhone, user.MobileNumber));

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
