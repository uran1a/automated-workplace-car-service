using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class EmployeeDTO : UserDTO
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
    }
}
