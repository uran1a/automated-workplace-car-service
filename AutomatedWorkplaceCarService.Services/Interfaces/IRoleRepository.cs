
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleAsync(string name);
        Task<Role?> GetRoleAsync(int id);
    }
}
