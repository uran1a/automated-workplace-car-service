using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<ICollection<Post>> GetAllPostsAsync(int postId);
        Task AddAsync(Employee newEmployee);
        void Update(Employee updatedEmployee);
        void Delete(Employee deletedEmployee);
    }
}
