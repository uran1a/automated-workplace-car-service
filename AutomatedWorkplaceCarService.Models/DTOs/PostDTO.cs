using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
