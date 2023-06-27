using AutomatedWorkplaceCarService.BLL.DTOs.Model;

namespace AutomatedWorkplaceCarService.BLL.DTOs.Brand
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModelDTO> Models { get; set; } = new();
    }
}
