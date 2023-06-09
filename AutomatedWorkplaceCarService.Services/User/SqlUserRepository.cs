using AutomatedWorkplaceCarService.Models;

namespace AutomatedWorkplaceCarService.Services
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public SqlUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? GetUserByLoginAndPassword(string login, string password)
        {
            return _context.Users.FirstOrDefault(p => p.Login == login && p.Password == password);
        }
    }
}
