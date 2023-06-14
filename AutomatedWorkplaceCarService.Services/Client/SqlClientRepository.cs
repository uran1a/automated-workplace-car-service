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

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClient(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public Client Update(Client updatedClient)
        {
            _context.Update(updatedClient);
            _context.SaveChanges();
            return updatedClient;
        }

        public Client Delete(int id)
        {
            var employeeToDelete = _context.Clients.FirstOrDefault(c => c.Id == id);
            if(employeeToDelete != null)
            {
                _context.Clients.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            return employeeToDelete;
        }
    }
}
