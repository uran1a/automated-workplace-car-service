using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Client : User
    {
        public string MobilePhone { get; set; }
        public List<Car> Cars { get; set; } = new();
        public List<Application> Applications { get; set; } = new();
    }
}
