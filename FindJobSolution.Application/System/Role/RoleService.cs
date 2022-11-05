using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.System.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.System.Role
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }

    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleVm>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return roles;
        }
    }
}