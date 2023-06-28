using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class ClientDTO : UserDTO
    {
        public string MobilePhone { get; set; }
        public List<CarDTO> Cars { get; set; } = new();
        public List<ApplicationDTO> Applications { get; set; } = new();
    }
}
