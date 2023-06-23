using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Role>> GetAllRolesAsync() => await _context.Roles.ToListAsync();
        public async Task<Role?> GetRoleAsync(string name) => await _context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(name));
        public async Task<Role?> GetRoleAsync(int id) => await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
    }
}
