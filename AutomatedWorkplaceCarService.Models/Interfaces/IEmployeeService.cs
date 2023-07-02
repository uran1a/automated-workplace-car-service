using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployeesAsync(int serviceId);
        Task<EmployeeDTO?> GetEmployeeAsync(int id);
        Task<List<EmployeeDTO>> GetAllEmployeesAsync(int id);
        Task<EmployeeDTO?> AddEmployeeAsync(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDTO);
        Task<EmployeeDTO?> DeleteEmployeeAsync(int id);
    }
}
