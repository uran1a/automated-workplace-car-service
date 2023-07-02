using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class TransmissionService : ITransmissionService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public TransmissionService(IUnitOfWork uow, IMapper mapper)
        {
            _db = uow;
            _mapper = mapper;
        }
        public async Task<List<TransmissionDTO>> GetAllTransmissionsAsync()
        {
            return _mapper.Map<List<TransmissionDTO>>(await _db.Transmissions.GetAllTransmissionsAsync());
        }
    }
}
