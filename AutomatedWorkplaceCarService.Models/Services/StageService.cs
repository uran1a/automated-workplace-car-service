using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class StageService : IStageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StageService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<StageDTO>> GetAllStagesAsync()
        {
            return _mapper.Map<List<StageDTO>>(await _context.Stages.ToListAsync());
        }
    }
}
