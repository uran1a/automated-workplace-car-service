using System.ComponentModel.DataAnnotations;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
