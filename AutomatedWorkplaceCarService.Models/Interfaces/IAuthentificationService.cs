using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IAuthentificationService
    {
        Task<UserDTO?> GetUserAsync(string login);
        Task<UserDTO?> GetUserAsync(string login, string password);
        Task<ClientDTO> AddClientAsync(ClientDTO clientDTO);
        Task<Dictionary<string, int>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleAsync(string name);
        Task<RoleDTO?> GetRoleAsync(int id);
    }
}
