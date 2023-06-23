using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task<ICollection<Client>> GetAllClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task<Client> AddAsync(Client newClient);
        void Update(Client updatedClient);
        void Delete(Client clientToDelete);
    }
}
