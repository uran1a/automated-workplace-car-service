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

        public async Task CompleteApplication(int id, string workshopAddress)
        {
            await _context.Applications
               .Where(a => a.Id == id)
               .ExecuteUpdateAsync(s => s
                   .SetProperty(a => a.StageId, e => 4)
                   .SetProperty(a => a.WorkshopAddress, e => workshopAddress));
        }

        public async Task DeleteAsync(int id)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
            if (application == null) return;
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ApplicationDTO>> GetAllApplicationsAsync()
        {
            var applications = await _context.Applications
                .Include(a => a.Car)
                .ThenInclude(c => c.Brand)
                .Include(a => a.Car)
                .ThenInclude(c => c.Model)
                .Include(a => a.Employee)
                .Include(a => a.Client)
                .Include(a => a.Stage).ToListAsync();
            return _mapper.Map<List<ApplicationDTO>>(applications);
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
                .ThenInclude(e => e.Post)
                .Include(a => a.Client)
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

        public async Task<List<ApplicaitonMasterCardDTO>> GetMasterApplications(int employeeId, int stageId)
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
                .Include(a => a.Client)
                .ToListAsync();
            return _mapper.Map<List<ApplicaitonMasterCardDTO>>(applications);
        }

        public async Task MakeApplicationConfirmed(int id)
        {
            await _context.Applications
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(a => a.StageId, e => 3));
        }

        public async Task<List<ApplicationCardDTO>> SearchAsync(string searchTerm, int clientId)
        {
            List<ApplicationCardDTO> applications = await this.GetApplications(clientId);
            if (string.IsNullOrWhiteSpace(searchTerm))
                return applications;
            return applications
                .Where(a => a.ModelName.ToLower().Contains(searchTerm.ToLower()) || 
                    a.BrandName.ToLower().Contains(searchTerm.ToLower()) ||
                    a.ServiceName.ToLower().Contains(searchTerm.ToLower())
                ).ToList();
        }
    }
}
