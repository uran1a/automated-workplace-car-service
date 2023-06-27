using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class TransmissionService : ITransmissionService
    {
        private readonly IUnitOfWork _db;
        public TransmissionService(IUnitOfWork uow)
        {
            _db = uow;
        }
        public async Task<List<TransmissionDTO>> GetAllTransmissionsAsync()
        {
            return Mapping.Mapper.Map<List<TransmissionDTO>>(await _db.Transmissions.GetAllTransmissionsAsync());
        }
    }
}
