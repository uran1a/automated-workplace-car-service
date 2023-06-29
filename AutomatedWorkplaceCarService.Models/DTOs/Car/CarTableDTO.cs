using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs.Car
{
    public class CarTableDTO
    {
        public int Id { get; set; }
        public int BrandName { get; set; }
        public int ModelName { get; set; }
        public int TransmissionName { get; set; }
        public int OwnerId { get; set; }
    }
}
