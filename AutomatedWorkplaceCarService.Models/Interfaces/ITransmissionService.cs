using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface ITransmissionService
    {
        Task<List<TransmissionDTO>> GetAllTransmissionsAsync();
    }
}
