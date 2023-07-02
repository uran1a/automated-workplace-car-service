using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IApplicationService
    {
        Task AddAsync(ApplicationDTO applicationDTO);
        Task<List<ApplicationDTO>> GetAllApplicationsAsync();
        Task<List<ApplicationCardDTO>> GetApplications(int clientId);
        Task<List<ApplicationCardDTO>> GetApplications(int employeeId, int stageId);
        Task<List<ApplicaitonMasterCardDTO>> GetMasterApplications(int employeeId, int stageId);
        Task<ApplicationDTO> GetApplication(int id);
        Task AddEvaluationApplicationAsync(EvaluationApplicationDTO evaluationApplicationDTO);
        Task MakeApplicationConfirmed(int id);
        Task CompleteApplication(int id, string workshopAddress);
        Task DeleteAsync(int id);
    }
}
