using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<ICollection<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO?> GetClientAsync(int id);
        Task<ClientDTO> AddClientAsync(ClientDTO clientDTO);
        Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO);
        Task<ClientDTO?> DeleteClientAsync(int id);
        Task<EmployeeDTO?> GetEmployeeAsync(int id);
        Task<ICollection<EmployeeDTO>> GetAllEmployeesAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDTO);
        Task<EmployeeDTO?> DeleteEmployeeAsync(int id);
        Task<ICollection<PostDTO>> GetAllPostsAsync(int postId);
    }
}
