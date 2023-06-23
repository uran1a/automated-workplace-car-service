using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string login);
        Task<User?> GetUserAsync(string login, string password);
    }
}
