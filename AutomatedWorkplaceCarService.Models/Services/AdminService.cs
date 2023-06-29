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
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork uow, IMapper mapper)
        {
            _db = uow;
            _mapper = mapper;
        }
        public async Task<ClientDTO?> AddClientAsync(ClientDTO clientDTO)
        {
            var cleint = _mapper.Map<Client>(clientDTO);
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
            var employee = _mapper.Map<Employee>(employeeDTO);
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
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<EmployeeDTO?> DeleteEmployeeAsync(int id)
        {
            var employee = await _db.Employees.GetEmployeeAsync(id);
            if (employee == null)
                return null;
            _db.Employees.Delete(employee);
            await _db.SaveAsync();
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<ClientDTO>> GetAllClientsAsync()
        {
            var clients = await _db.Clients.GetAllClientsAsync();
            if (clients == null)
                clients = new List<Client>();
            return _mapper.Map<List<ClientDTO>>(clients);
        }
        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(int id)
        {
            var employees = await _db.Employees.GetAllEmployeesAsync();
            if (employees == null)
                employees = new List<Employee>();
            else
                employees = employees.Where(e => e.Id != id).ToList();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<List<PostDTO>> GetAllPostsAsync(int postId)
        {
            return _mapper.Map<List<PostDTO>>(await _db.Posts.GetAllPostsAsync(postId));
        }

        public async Task<ClientDTO?> GetClientAsync(int id)
        {
            return _mapper.Map<ClientDTO>(await _db.Clients.GetClientAsync(id));
        }
         
        public async Task<EmployeeDTO?> GetEmployeeAsync(int id)
        {
            return _mapper.Map<EmployeeDTO>(await _db.Employees.GetEmployeeAsync(id));
        }

        public async Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            _db.Clients.Update(client);
            await _db.SaveAsync();
            return clientDTO;
        }
        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            _db.Employees.Update(employee);
            await _db.SaveAsync();
            return employeeDTO;
        }
    }
}
