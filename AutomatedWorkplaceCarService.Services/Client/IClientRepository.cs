using AutomatedWorkplaceCarService.Models;

namespace AutomatedWorkplaceCarService.Services
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClient(int id);
        Client GetClientByLogin(string login);
        Client Add(Client newClient);
        Client Update(Client updatedClient);
        Client Delete(int id);
    }
}
