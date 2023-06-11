using AutomatedWorkplaceCarService.Models;

namespace AutomatedWorkplaceCarService.Services
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientByLogin(string login);
        Client Add(Client client);
    }
}
