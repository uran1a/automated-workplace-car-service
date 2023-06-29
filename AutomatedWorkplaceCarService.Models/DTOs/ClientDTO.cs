using AutomatedWorkplaceCarService.BLL.DTOs.Car;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class ClientDTO : UserDTO
    {
        public string MobilePhone { get; set; }
        public List<CarDTO> Cars { get; set; } = new();
        public List<ApplicationDTO> Applications { get; set; } = new();
    }
}
