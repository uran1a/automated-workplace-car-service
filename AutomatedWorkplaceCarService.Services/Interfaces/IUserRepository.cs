using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByLoginAndPassword(string login, string password);
    }
}
