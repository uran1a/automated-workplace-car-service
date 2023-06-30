using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployeesAsync(int serviceId);
    }
}
