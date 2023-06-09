using AutomatedWorkplaceCarService.Models;

namespace AutomatedWorkplaceCarService.Services
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public SqlClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Client Add(Client newClient)
        {
            newClient.Role = Role.Client;
            _context.Clients.Add(newClient);
            _context.SaveChanges();
            return newClient;
        }

        public Client GetClientByLogin(string login)
        {
            return _context.Clients.FirstOrDefault(c => c.Login == login);
        }
    }
}
