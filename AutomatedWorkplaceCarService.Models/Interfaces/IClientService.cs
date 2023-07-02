using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO?> AddClientAsync(ClientDTO clientDTO);
        Task<List<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO?> GetClientAsync(int id);
        Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO);
        Task<ClientDTO?> DeleteClientAsync(int id);
    }
}
