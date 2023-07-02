using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public UserService(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<UserDTO?> GetUserAsync(string login)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Login.Equals(login));
			if (user == null) return null;
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO?> GetUserAsync(string login, string password)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Login.Equals(login) && u.Password.Equals(password));
			if (user == null) return null;
			return _mapper.Map<UserDTO>(user);
		}
	}
}
