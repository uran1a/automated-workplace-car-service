using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(ApplicationDTO applicationDTO)
        {
            var application = _mapper.Map<Application>(applicationDTO);
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
        }

        public List<ApplicationCardDTO> GetApplications(int clientId)
        {
            var applications = _context.Applications
                .Where(a => a.ClientId == clientId)
                .Include(a => a.Service)
                .Include(a => a.Car)
                .ThenInclude(c => c.Brand)
                .Include(a => a.Car)
                .ThenInclude(c => c.Model)
                .Include(a => a.Car)
                .ThenInclude(c => c.Images)
                .Include(a => a.Stage).ToList();
            return _mapper.Map<List<ApplicationCardDTO>>(applications);
        }
    }
}
