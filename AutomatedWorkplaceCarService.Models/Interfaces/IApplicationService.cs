using AutomatedWorkplaceCarService.BLL.DTOs;
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
    }
}
