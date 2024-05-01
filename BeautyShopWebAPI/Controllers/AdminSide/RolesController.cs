using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs.AdminSide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers.AdminSide
{
    [Route("api/Roles")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpGet]
        public async Task<ActionResult> GetListOfRoles(CancellationToken cancellation = default)
        {
            return Ok(await _roleService.GetListOfRoleDTOs(cancellation));
        }


        [HttpGet("{roleId}")]
        public async Task<ActionResult> GetRoleById(int roleId, CancellationToken cancellation = default)
        {
            var role = await _roleService.GetRoleDTOByRoleId(roleId, cancellation);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(CreateRoleDTO roleDTO, CancellationToken cancellation = default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _roleService.CreateRole(roleDTO, cancellation);
            if (!result) return BadRequest("There is a role with this name");
            return Ok("Role Created Successfully");
        }

        [HttpPut("{roleId}")]
        public async Task<ActionResult> EditRole(int roleId,EditRoleDTO roleDTO,CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _roleService.EditRole(roleId, roleDTO, cancellation);
            if (!result.Successful) return BadRequest(result.Message);
            return Ok("Role edited successfully");
        }

        [HttpDelete("{roleId}")]
        public async Task<ActionResult> DeleteRole(int roleId,CancellationToken cancellation=default)
        {
            var result = await _roleService.DeleteRole(roleId, cancellation);
            if (!result) return NotFound("There is no role with this Id");
            return Ok("Role Deleted Successfully");
        }
    }
}
