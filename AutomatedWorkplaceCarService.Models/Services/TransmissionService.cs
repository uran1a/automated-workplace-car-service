using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class TransmissionService : ITransmissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TransmissionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TransmissionDTO>> GetAllTransmissionsAsync()
        {
            return _mapper.Map<List<TransmissionDTO>>(await _context.Transmissions.ToListAsync());
        }
    }
}
