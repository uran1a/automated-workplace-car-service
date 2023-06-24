using AutomatedWorkplaceCarService.DAL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ApplicationRepository applicationRepository;
        /*public CarRepository carRepository;*/
        public ClientRepository clientRepository;
        public EmployeeRepository employeeRepository;
        public UserRepository userRepository;
        public RoleRepository roleRepository;
        public PostRepository postRepository;
        
        public IApplicationRepository Applications
        {
            get
            {
                if(applicationRepository == null)
                    applicationRepository = new ApplicationRepository(_context);
                return applicationRepository;
            }
        }
       /* public ICarRepository Cars
        {
            get
            {
                if(carRepository == null)
                    carRepository = new CarRepository(_context);
                return carRepository;
            }
        }*/
        public IClientRepository Clients
        {
            get
            {
                if(clientRepository == null)
                    clientRepository = new ClientRepository(_context);
                return clientRepository;
            }
        }
        
        public IEmployeeRepository Employees
        {
            get
            {
                if(employeeRepository == null)
                    employeeRepository = new EmployeeRepository(_context);
                return employeeRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if(roleRepository == null)
                    roleRepository = new RoleRepository(_context);
                return roleRepository;
            }
        }
        public IPostRepository Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(_context);
                return postRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
