using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
	public class ClientService : IClientService
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IRoleService _roleService;

		public ClientService(ApplicationDbContext context, IMapper mapper, IRoleService roleService)
		{
			_context = context;
			_mapper = mapper;
			_roleService = roleService;
		}

		public async Task<ClientDTO?> AddClientAsync(ClientDTO clientDTO)
		{
			var client = _mapper.Map<Client>(clientDTO);
			var role = await _roleService.GetRoleAsync("client");
			if (role == null) return null;
			client.RoleId = role.Id;
			await _context.Clients.AddAsync(client);
			await _context.SaveChangesAsync();
			return clientDTO;
		}

        public async Task<ClientDTO?> DeleteClientAsync(int id)
        {
			var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
			if (client == null)
				return null;
			_context.Clients.Remove(client);
			await _context.SaveChangesAsync();
			return _mapper.Map<ClientDTO>(client);
		}

        public async Task<List<ClientDTO>> GetAllClientsAsync()
        {
			var clients = await _context.Clients.ToListAsync();
			if (clients == null)
				clients = new List<Client>();
			return _mapper.Map<List<ClientDTO>>(clients);
		}

        public async Task<ClientDTO?> GetClientAsync(int id)
        {
			var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
			if (client == null) return null;
			return _mapper.Map<ClientDTO>(client);
		}

        public async Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO)
        {
			var client = _mapper.Map<Client>(clientDTO);
			_context.Clients.Update(client);
			await _context.SaveChangesAsync();
			return clientDTO;
        }
    }
}
