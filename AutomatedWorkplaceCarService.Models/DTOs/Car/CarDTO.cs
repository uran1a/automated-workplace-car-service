using AutomatedWorkplaceCarService.BLL.DTOs.Brand;
using AutomatedWorkplaceCarService.BLL.DTOs.Model;
using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs.Car
{
    public class CarDTO
    {
        public int Id { get; set; }
        public int YearOfRelease { get; set; }
        public int EnginePower { get; set; }
        public int ModelId { get; set; }
        public ModelDTO Model { get; set; }
        public int BrandId { get; set; }
        public BrandDTO Brand { get; set; }
        public int TransmissionId { get; set; }
        public TransmissionDTO Transmission { get; set; }
        public int OwnerId { get; set; }
        public ClientDTO Owner { get; set; }
        public List<ApplicationDTO> Applications { get; set; } = new();
        public List<ImageDTO> Images { get; set; } = new();
    }
}
