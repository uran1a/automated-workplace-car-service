using AutomatedWorkplaceCarService.Models;

namespace AutomatedWorkplaceCarService.Services
{
    public interface IClientRepository
    {
        Client GetClientByLogin(string login);
        Client Add(Client client);
    }
}
