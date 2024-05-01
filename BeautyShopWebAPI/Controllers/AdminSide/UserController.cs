using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs.AdminSide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers.AdminSide
{
    [Route("api/User")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult> GetListOfUsers(CancellationToken cancellation=default)
        {
            return Ok(await _userService.GetListOfUsers(cancellation));
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserById(int userId,CancellationToken cancellation=default)
        {
            var userDTO = await _userService.GetUserDTOById(userId, cancellation);
            if(userDTO==null) return NotFound();
            return Ok(userDTO);
        }


        [HttpPut("{userId}")]
        public async Task<ActionResult> EditUser(int userId,EditUserDTO userDTO,
            CancellationToken cancellation=default)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var res = await _userService.EditUser(userId, userDTO, cancellation);
            if(res) return Ok("User edited successfully");
            return BadRequest();
        }


        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId,CancellationToken cancellation=default)
        {
            var result = await _userService.DeleteUser(userId, cancellation);
            if (!result) return NotFound();
            return Ok("User deleted successfully");
        }
    }
}
