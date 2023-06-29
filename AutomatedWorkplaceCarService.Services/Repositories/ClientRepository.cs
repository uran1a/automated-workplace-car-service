using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class ClientRepository : IClientRepository
{
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Client newClient)
        {
            await _context.Clients.AddAsync(newClient);
        }
        public async Task<Client?> GetClientAsync(string login) => await _context.Clients.FirstOrDefaultAsync(c => c.Login == login);
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.Include(c => c.Role).ToListAsync();
        }
        public async Task<Client?> GetClientAsync(int id) => await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        public void Update(Client updatedClient)
        {
            _context.Clients.Update(updatedClient);
        }
        public void Delete(Client clientToDelete)
        {
            _context.Clients.Remove(clientToDelete);
        }
    }
}
