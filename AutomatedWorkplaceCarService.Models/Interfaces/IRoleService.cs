using AutomatedWorkplaceCarService.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
	public interface IRoleService
	{
		Task<Dictionary<string, int>> GetAllRolesAsync();
		Task<RoleDTO?> GetRoleAsync(string name);
		Task<RoleDTO?> GetRoleAsync(int id);
	}
}
