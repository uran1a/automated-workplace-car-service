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
            _mapperClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            _mapperEmployee = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            _mapperPost = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostDTO>()).CreateMapper();
        }
        public async Task<ClientDTO> AddClientAsync(ClientDTO clientDTO)
        {
            var cleint = _mapperClient.Map<Client>(clientDTO);
            var newClient = await _db.Clients.AddAsync(cleint);
            await _db.SaveAsync();
            return _mapperClient.Map<ClientDTO>(newClient);
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapperClient.Map<Employee>(employeeDTO);
            var newEmployee = await _db.Employees.AddAsync(employee);
            await _db.SaveAsync();
            return _mapperClient.Map<EmployeeDTO>(newEmployee);
        }

        public async Task<ClientDTO?> DeleteClientAsync(int id)
        {
            var client = await _db.Clients.GetClientAsync(id);
            if (client == null)
                return null;
            var deletedClientDTO = _mapperClient.Map<ClientDTO>(_db.Clients.Delete(client));
            await _db.SaveAsync();
            return deletedClientDTO;
        }

        public async Task<EmployeeDTO?> DeleteEmployeeAsync(int id)
        {
            var employee = await _db.Employees.GetEmployeeAsync(id);
            if (employee == null)
                return null;
            var deletedClientDTO = _mapperClient.Map<EmployeeDTO>(_db.Employees.Delete(employee));
            await _db.SaveAsync();
            return deletedClientDTO;
        }

        public async Task<ICollection<ClientDTO>> GetAllClientsAsync()
        {
            return _mapperClient.Map<ICollection<ClientDTO>>(await _db.Clients.GetAllClientsAsync());
        }

        public async Task<ICollection<EmployeeDTO>> GetAllEmployeesAsync(int id)
        {
            var employees = await _db.Employees.GetAllEmployeesAsync();
            employees = employees.Where(e => e.Id != id).ToList();
            return _mapperEmployee.Map<ICollection<EmployeeDTO>>(employees);
        }

        public async Task<ICollection<PostDTO>> GetAllPostsAsync(int postId)
        {
            return _mapperPost.Map<ICollection<PostDTO>>(await _db.Posts.GetAllPostsAsync(postId));
        }

        public async Task<ClientDTO?> GetClientAsync(int id)
        {
            return _mapperClient.Map<ClientDTO>(await _db.Clients.GetClientAsync(id));
        }
         
        public async Task<EmployeeDTO?> GetEmployeeAsync(int id)
        {
            return _mapperClient.Map<EmployeeDTO>(await _db.Employees.GetEmployeeAsync(id));
        }

        public async Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO)
        {
            var client = _mapperClient.Map<Client>(clientDTO);
            var updatedClient = _mapperClient.Map<ClientDTO>(_db.Clients.Update(client));
            await _db.SaveAsync();
            return updatedClient;
        }
        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapperClient.Map<Employee>(employeeDTO);
            var updatedEmployeeDTO = _mapperClient.Map<EmployeeDTO>(_db.Employees.Update(employee));
            await _db.SaveAsync();
            return updatedEmployeeDTO;
        }
    }
}
