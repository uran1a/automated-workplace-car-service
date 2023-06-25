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
        private readonly IMapper _mapperClient;
        private readonly IMapper _mapperUser;
        private readonly IMapper _mapperRole;
        public AuthentificationService(IUnitOfWork uow)
        {
            _db = uow;
            _mapperClient = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClientDTO, Client>().ReverseMap();
            }).CreateMapper();
            _mapperUser = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>().ReverseMap();
            }).CreateMapper();
            _mapperRole = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleDTO, Role>().ReverseMap();
            }).CreateMapper();
        }
        public async Task<ClientDTO?> AddClientAsync(ClientDTO clientDTO)
        {
            var cleint = _mapperClient.Map<Client>(clientDTO);
            var role = await _db.Roles.GetRoleAsync("client");
            if (role == null)
                return null;
            cleint.RoleId = role.Id;
            await _db.Clients.AddAsync(cleint);
            await _db.SaveAsync();
            return clientDTO;

            /*var cleint = mapper.Map<Client>(clientDTO);
            var role = await _db.Roles.GetRoleAsync("client");
            if (role == null)
                return null;
            cleint.RoleId = role.Id;
            cleint.Role = role;
            await _db.Clients.AddAsync(cleint);
            await _db.SaveAsync();  
            ClientDTO newClientDTO = mapper.Map<Client, ClientDTO>(cleint);
            return newClientDTO;*/
        }
        public async Task<Dictionary<string, int>> GetAllRolesAsync()
        {
            var roleDTOs = _mapperRole.Map<ICollection<RoleDTO>>(await _db.Roles.GetAllRolesAsync());
            Dictionary<string, int> mapRoles = new Dictionary<string, int>();
            foreach (var role in roleDTOs)
                mapRoles.Add(role.Name, role.Id);
            return mapRoles;
        }
        public async Task<RoleDTO?> GetRoleAsync(string name)
        {
            return _mapperRole.Map<RoleDTO>(await _db.Roles.GetRoleAsync(name));
        }
        public async Task<RoleDTO?> GetRoleAsync(int id)
        {
            return _mapperRole.Map<RoleDTO>(await _db.Roles.GetRoleAsync(id));
        }
        public async Task<UserDTO?> GetUserAsync(string login)
        {
            return _mapperUser.Map<UserDTO?>(await _db.Users.GetUserAsync(login));
        }
        public async Task<UserDTO?> GetUserAsync(string login, string password)
        {
            return _mapperUser.Map<UserDTO?>(await _db.Users.GetUserAsync(login, password));
        }
    }
}
