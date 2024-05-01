using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;

namespace BeautyShopApplication.Services.Interface;

public interface IRoleService
{
    Task<ICollection<RoleDTO>?> GetListOfRoleDTOs(CancellationToken cancellation);
    Task<RoleDTO?> GetRoleDTOByRoleId(int roleId, CancellationToken cancellation);
    Task<bool> CreateRole(CreateRoleDTO roleDTO, CancellationToken cancellation);
    Task<EditRoleResponse> EditRole(int roleId, EditRoleDTO roleDTO, CancellationToken cancellation);
    Task<bool> DeleteRole(int roleId, CancellationToken cancellation);
}
