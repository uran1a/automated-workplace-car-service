using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IStageService
    {
        Task<List<StageDTO>> GetAllStagesAsync();
    }
}
