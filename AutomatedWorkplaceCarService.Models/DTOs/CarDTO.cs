using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public int YearOfRelease { get; set; }
        public int EnginePower { get; set; }
        public int ModelId { get; set; }
        public ModelDTO Model { get; set; }
        public int TransmissionId { get; set; }
        public TransmissionDTO Transmission { get; set; }
        public int OwnerId { get; set; }
        public ClientDTO Owner { get; set; }
        public List<ApplicationDTO> Applications { get; set; } = new();
        public List<ImageDTO> Images { get; set; } = new();
    }
}
