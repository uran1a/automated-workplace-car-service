using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
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
