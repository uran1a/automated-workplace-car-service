using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapperClient;
        private readonly IMapper _mapperEmployee;
        private readonly IMapper _mapperPost;
        public AdminService(IUnitOfWork uow)
        {
            _db = uow;
            _mapperClient = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClientDTO, Client>().ReverseMap();
            }).CreateMapper();
            _mapperEmployee = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>().ReverseMap();
            }).CreateMapper();
            _mapperPost = new MapperConfiguration(cfg => {
                cfg.CreateMap<PostDTO, Post>().ReverseMap();
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
        }

        public async Task<EmployeeDTO?> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapperEmployee.Map<Employee>(employeeDTO);
            var role = await _db.Roles.GetRoleAsync("employee");
            if (role == null)
                return null;
            employee.RoleId = role.Id;
            await _db.Employees.AddAsync(employee);
            await _db.SaveAsync();
            return employeeDTO;
        }

        public async Task<ClientDTO?> DeleteClientAsync(int id)
        {
            var client = await _db.Clients.GetClientAsync(id);
            if (client == null)
                return null;
            _db.Clients.Delete(client);
            await _db.SaveAsync();
            return _mapperClient.Map<ClientDTO>(client);
        }

        public async Task<EmployeeDTO?> DeleteEmployeeAsync(int id)
        {
            var employee = await _db.Employees.GetEmployeeAsync(id);
            if (employee == null)
                return null;
            _db.Employees.Delete(employee);
            await _db.SaveAsync();
            return _mapperEmployee.Map<EmployeeDTO>(employee);
        }

        public async Task<List<ClientDTO>> GetAllClientsAsync()
        {
            var clients = await _db.Clients.GetAllClientsAsync();
            if (clients == null)
                clients = new List<Client>();
            return _mapperClient.Map<List<ClientDTO>>(clients);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(int id)
        {
            var employees = await _db.Employees.GetAllEmployeesAsync();
            if (employees == null)
                employees = new List<Employee>();
            else
                employees = employees.Where(e => e.Id != id).ToList();
            return _mapperEmployee.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<List<PostDTO>> GetAllPostsAsync(int postId)
        {
            return _mapperPost.Map<List<PostDTO>>(await _db.Posts.GetAllPostsAsync(postId));
        }

        public async Task<ClientDTO?> GetClientAsync(int id)
        {
            return _mapperClient.Map<ClientDTO>(await _db.Clients.GetClientAsync(id));
        }
         
        public async Task<EmployeeDTO?> GetEmployeeAsync(int id)
        {
            return _mapperEmployee.Map<EmployeeDTO>(await _db.Employees.GetEmployeeAsync(id));
        }

        public async Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO)
        {
            var client = _mapperClient.Map<Client>(clientDTO);
            _db.Clients.Update(client);
            await _db.SaveAsync();
            return clientDTO;
        }
        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapperEmployee.Map<Employee>(employeeDTO);
            _db.Employees.Update(employee);
            await _db.SaveAsync();
            return employeeDTO;
        }
    }
}
