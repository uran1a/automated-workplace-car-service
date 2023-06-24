using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<ICollection<Post>> GetAllPostsAsync(int postId);
        Task<Employee> AddAsync(Employee newEmployee);
        Employee Update(Employee updatedEmployee);
        Employee Delete(Employee deletedEmployee);
    }
}
