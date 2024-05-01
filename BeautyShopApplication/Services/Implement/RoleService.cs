using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopApplication.Services.Implement;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }


    public async Task<ICollection<RoleDTO>?> GetListOfRoleDTOs(CancellationToken cancellation)
    {
        return await _roleRepository.GetListOfRolDTOs(cancellation);
    }

    public async Task<RoleDTO?> GetRoleDTOByRoleId(int roleId, CancellationToken cancellation)
    {
        return await _roleRepository.GetRoleDTOByRoleId(roleId, cancellation);
    }

    public async Task<bool> CreateRole(CreateRoleDTO roleDTO, CancellationToken cancellation)
    {
        var roleExists = await _roleRepository.RoleExistsWithName(roleDTO.RoleUniqueName, cancellation);
        if (roleExists) return false;

        var role = new Role() { UniqueName = roleDTO.RoleUniqueName };

        _roleRepository.AddRole(role);
        await _roleRepository.SaveChangesAsync(cancellation);

        return true;
    }

    public async Task<EditRoleResponse> EditRole(int roleId,EditRoleDTO roleDTO, CancellationToken cancellation)
    {
        var roleExists = await _roleRepository.RoleExistsWithName_ForEditRole(roleId, roleDTO.RoleUniqueName, cancellation);
        if(roleExists) return new EditRoleResponse(false,"There is another role with this name");

        var role = await _roleRepository.GetRoleById(roleId, cancellation);
        if (role == null) return new EditRoleResponse(false, "There is no Role with this Id");

        role.UniqueName = roleDTO.RoleUniqueName;
        _roleRepository.UpdateRole(role);
        await _roleRepository.SaveChangesAsync(cancellation);

        return new EditRoleResponse(true, "Role Edited Successfully");
    }


    public async Task<bool> DeleteRole(int roleId,CancellationToken cancellation)
    {
        var role = await _roleRepository.GetRoleById(roleId, cancellation);
        if (role == null) return false;

        role.IsDelete = true;
        _roleRepository.UpdateRole(role);
        await _roleRepository.SaveChangesAsync(cancellation);

        return true;
    }
}
