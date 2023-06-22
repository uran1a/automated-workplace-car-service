using System.ComponentModel.DataAnnotations;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<User> Users = new List<User>();
    }
}
