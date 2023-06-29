using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IServiceService
    {
        List<ServiceDTO> GetAvailableServices();
    }
}
