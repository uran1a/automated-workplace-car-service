using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
	public class RoleService : IRoleService
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public RoleService(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<Dictionary<string, int>> GetAllRolesAsync()
		{
			var roleDTOs = _mapper.Map<List<RoleDTO>>(await _context.Roles.ToListAsync());
			Dictionary<string, int> mapRoles = new Dictionary<string, int>();
			foreach (var role in roleDTOs)
				mapRoles.Add(role.Name, role.Id);
			return mapRoles;
		}

		public async Task<RoleDTO?> GetRoleAsync(string name)
		{
			var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(name));
			if (role == null) return null;
			return _mapper.Map<RoleDTO>(role);
		}

		public async Task<RoleDTO?> GetRoleAsync(int id)
		{
			var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
			if (role == null) return null;
			return _mapper.Map<RoleDTO>(role);
		}
	}
}
