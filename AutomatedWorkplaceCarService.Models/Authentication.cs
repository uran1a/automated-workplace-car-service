using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Application
    {
        public int Id { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int? Amount { get; set; }
        public string Descriptions { get; set; }
        public Stage Stage { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
