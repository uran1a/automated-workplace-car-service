using AutomatedWorkplaceCarService.DAL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IApplicationRepository applicationRepository;
        public IPostRepository postRepository;
        public IBrandRepository brandRepository;
        public IModelRepository modelRepository;
        public ITransmissionRepository transmissionRepository;
        public IImageRepository imageRepository;

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

        public IImageRepository Images
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new ImageRepository(_context);
                return imageRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
