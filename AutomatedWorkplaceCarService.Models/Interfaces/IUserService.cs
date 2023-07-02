using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO?> GetUserAsync(string login);
		Task<UserDTO?> GetUserAsync(string login, string password);
	}
}
