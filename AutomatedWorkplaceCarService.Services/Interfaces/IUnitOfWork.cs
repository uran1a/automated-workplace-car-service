using AutomatedWorkplaceCarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IApplicationRepository Applications { get; }
        ICarRepository Cars { get; }
        IClientRepository Clients { get; }
        IEmployeeRepository Employees { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IPostRepository Posts { get; }
        IBrandRepository Brands { get; }
        IModelRepository Models { get; }
        ITransmissionRepository Transmissions { get; }
        IImageRepository Images { get; }
        Task SaveAsync();
    }
}
