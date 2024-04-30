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
        public async Task<ActionResult> RegisterUser(RegisterUserDTO registerUserDTO,CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _accountService.RegisterUser(registerUserDTO, cancellation);
            if(!result) return BadRequest("A User Exists With This MobileNumber");
            return Ok("Registered Successfully");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserDTO loginUserDTO,CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _accountService.LoginUser(loginUserDTO, cancellation);
            if (!response.Successful) return Unauthorized("Mobile Or Password is wrong");
            return Ok(response.Token);
        }

    }
}
