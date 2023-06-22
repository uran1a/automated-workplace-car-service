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
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
