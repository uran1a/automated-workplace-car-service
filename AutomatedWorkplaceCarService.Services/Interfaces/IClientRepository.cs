using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task AddAsync(Client newClient);
        void Update(Client updatedClient);
        void Delete(Client clientToDelete);
    }
}
