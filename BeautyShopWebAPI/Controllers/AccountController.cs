using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUser(RegisterUserDTO registerUserDTO,CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _accountService.RegisterUser(registerUserDTO, cancellation);
            if(!response.Successful) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginUserResponse>> Login(LoginUserDTO loginUserDTO,CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _accountService.LoginUser(loginUserDTO, cancellation);
            if (!response.Successful) return Unauthorized(response);
            return Ok(response);
        }

    }
}
