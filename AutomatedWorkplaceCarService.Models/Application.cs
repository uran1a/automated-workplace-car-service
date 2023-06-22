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
        [Required]
        public DateTime StartWork { get; set; }
        [Required]
        public DateTime EndWork { get; set; }
        public int? Amount { get; set; }
        public string Descriptions { get; set; }
        [Required]
        public Stage Stage { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }
        public List<Image> Images { get; set; }
    }   
}
