﻿using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceDTO>> GetAvailableServices();
    }
}
