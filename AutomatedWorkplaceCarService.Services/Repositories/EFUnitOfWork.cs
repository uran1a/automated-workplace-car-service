using AutomatedWorkplaceCarService.DAL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IApplicationRepository applicationRepository;
        /*public CarRepository carRepository;*/
        public IClientRepository clientRepository;
        public IEmployeeRepository employeeRepository;
        public IUserRepository userRepository;
        public IRoleRepository roleRepository;
        public IPostRepository postRepository;
        public IBrandRepository brandRepository;
        public IModelRepository modelRepository;
        public ITransmissionRepository transmissionRepository;

        public EFUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
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

        public IBrandRepository Brands
        {
            get
            {
                if (brandRepository == null)
                    brandRepository = new BrandRepository(_context);
                return brandRepository;
            }
        }
        public IModelRepository Models
        {
            get
            {
                if (modelRepository == null)
                    modelRepository = new ModelRepository(_context);
                return modelRepository;
            }
        }

        public ITransmissionRepository Transmissions
        {
            get
            {
                if (transmissionRepository == null)
                    transmissionRepository = new TransmissionRepository(_context);
                return transmissionRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
