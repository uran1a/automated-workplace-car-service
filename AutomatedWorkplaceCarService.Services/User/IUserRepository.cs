using AutomatedWorkplaceCarService.Models;

namespace AutomatedWorkplaceCarService.Services
{
    public interface IUserRepository
    {
        User? GetUserByLoginAndPassword(string login, string password);
    }
}
