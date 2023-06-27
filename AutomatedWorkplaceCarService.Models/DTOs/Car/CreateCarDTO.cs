using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs.Car
{
    public class CreateCarDTO
    {
        public int YearOfRelease { get; set; }
        public int EnginePower { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int TransmissionId { get; set; }
        public int OwnerId { get; set; }
        public List<ImageDTO> Images { get; set; } = new();
    }
}
