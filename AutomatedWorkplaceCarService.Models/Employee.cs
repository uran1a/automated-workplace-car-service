using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Employee : User
    {
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        public List<Application> Applications { get; set; }
        public Employee()
        {
            Applications = new List<Application>();
        }
    }
}
