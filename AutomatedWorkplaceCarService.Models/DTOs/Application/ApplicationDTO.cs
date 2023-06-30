using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs.Application
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int Amount { get; set; }
        public string Descriptions { get; set; }
        public int StageId { get; set; }
        public StageDTO Stage { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int ServiceId { get; set; }
        public ServiceDTO Service { get; set; }
        public int CarId { get; set; }
        public CarDTO Car { get; set; }
    }
}