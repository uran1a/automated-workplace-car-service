using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserAsync(string login) => await _context.Users.FirstOrDefaultAsync(u => u.Login.Equals(login));
        public async Task<User?> GetUserAsync(string login, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login.Equals(login) && u.Password.Equals(password));
        }
    }
}
