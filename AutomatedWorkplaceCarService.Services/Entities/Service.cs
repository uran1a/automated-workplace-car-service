using System.ComponentModel.DataAnnotations;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Specialization> Specializations { get; set; } = new();
    }
}
