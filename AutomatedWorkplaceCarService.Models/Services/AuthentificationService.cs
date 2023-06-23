using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUnitOfWork _db;
        public AuthentificationService(IUnitOfWork uow)
        {
            _db = uow;
        }
        public async Task<ClientDTO> AddClientAsync(ClientDTO clientDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            var cleint = mapper.Map<Client>(clientDTO);
            await _db.Clients.AddAsync(cleint);
            await _db.SaveAsync();
            return clientDTO;
        }
        public async Task<Dictionary<string, int>> GetAllRolesAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            var roleDTOs = mapper.Map<ICollection<RoleDTO>>(await _db.Roles.GetAllRolesAsync());
            Dictionary<string, int> mapRoles = new Dictionary<string, int>();
            foreach (var role in roleDTOs)
                mapRoles.Add(role.Name, role.Id);
            return mapRoles;
        }
        public async Task<RoleDTO?> GetRoleAsync(string name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<RoleDTO>(await _db.Roles.GetRoleAsync(name));
        }
        public async Task<RoleDTO?> GetRoleAsync(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<RoleDTO>(await _db.Roles.GetRoleAsync(id));
        }
        public async Task<UserDTO?> GetUserAsync(string login)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<UserDTO?>(await _db.Users.GetUserAsync(login));
        }
        public async Task<UserDTO?> GetUserAsync(string login, string password)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<UserDTO?>(await _db.Users.GetUserAsync(login, password));
        }
    }
}
