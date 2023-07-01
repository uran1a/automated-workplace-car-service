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

        public async Task AddEvaluationApplicationAsync(EvaluationApplicationDTO evaluationApplicationDTO)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == evaluationApplicationDTO.Id);
            if (application == null) return;
            application.StartWork = evaluationApplicationDTO.StartWork;
            application.EndWork = evaluationApplicationDTO.EndWork;
            application.Amount = evaluationApplicationDTO.Amount;
            application.StageId = 2;

            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
            if (application == null) return;
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationDTO> GetApplication(int id)
        {
            var application = await _context.Applications
                .Include(a => a.Service)
                .Include(a => a.Car)
                .ThenInclude(c => c.Brand)
                .Include(a => a.Car)
                .ThenInclude(c => c.Model)
                .Include(a => a.Car)
                .ThenInclude(c => c.Transmission)
                .Include(a => a.Car)
                .ThenInclude(c => c.Images)
                .Include(a => a.Stage)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<ApplicationDTO>(application);
        }

        public async Task<List<ApplicationCardDTO>> GetApplications(int clientId)
        {
            var applications = await _context.Applications
                .Where(a => a.ClientId == clientId)
                .Include(a => a.Service)
                .Include(a => a.Car)
                .ThenInclude(c => c.Brand)
                .Include(a => a.Car)
                .ThenInclude(c => c.Model)
                .Include(a => a.Car)
                .ThenInclude(c => c.Images)
                .Include(a => a.Stage)
                .ToListAsync();
            return _mapper.Map<List<ApplicationCardDTO>>(applications);
        }

        public async Task<List<ApplicationCardDTO>> GetApplications(int employeeId, int stageId)
        {
            var applications = await _context.Applications
                .Where(a => a.EmployeeId == employeeId && a.StageId == stageId)
                .Include(a => a.Service)
                .Include(a => a.Car)
                .ThenInclude(c => c.Brand)
                .Include(a => a.Car)
                .ThenInclude(c => c.Model)
                .Include(a => a.Car)
                .ThenInclude(c => c.Images)
                .Include(a => a.Stage)
                .ToListAsync();
            return _mapper.Map<List<ApplicationCardDTO>>(applications);
        }

        public async Task MakeApplicationConfirmed(int id)
        {
            await _context.Applications
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(a => a.StageId, e => 3));
        }
    }
}
