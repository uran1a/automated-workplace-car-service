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
        List<ApplicationCardDTO> GetApplications(int clientId);
    }
}
