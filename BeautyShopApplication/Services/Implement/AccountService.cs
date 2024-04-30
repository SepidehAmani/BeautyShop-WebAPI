using BeautyShopApplication.Services.Interface;
using BeautyShopApplication.Utilities;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
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
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;
    public AccountService(IUserRepository userRepository, IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _userManager = userManager;
    }


    public async Task<bool> RegisterUser (RegisterUserDTO userDTO, CancellationToken cancellation)
    {
        var user = new IdentityUser()
        {
            UserName = userDTO.Email,
            Email = userDTO.Email,
            PhoneNumber = userDTO.Mobile
        };

        var result = await _userManager.CreateAsync(user, userDTO.Password);

        if(result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(user, "NormalUser");
            if(result.Succeeded)
            {
                return true;
            }
        }

        return false;
    }


    public async Task<LoginUserResponse> LoginUser(LoginUserDTO userDTO, CancellationToken cancellation)
    {
        var user = await _userManager.FindByEmailAsync(userDTO.Email);
        if (user == null) return new LoginUserResponse(false, "");
        var result = await _userManager.CheckPasswordAsync(user, userDTO.Password);
        if(!result) return new LoginUserResponse(false, "");

        var roles = await _userManager.GetRolesAsync(user);
        var token = GetToken(user,roles);

        return new LoginUserResponse(true, token);
    }


    string GetToken(IdentityUser user , IList<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
                );
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claimsForToken.Add(new Claim(ClaimTypes.Name, user.UserName));
        claimsForToken.Add(new Claim(ClaimTypes.Email, user.Email));

        foreach (var role in roles)
        {
            claimsForToken.Add(new Claim(ClaimTypes.Role, role));
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
