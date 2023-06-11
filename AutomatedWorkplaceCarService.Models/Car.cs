using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public int YearOfRelease { get; set; }
        [Required]
        public int EnginePower { get; set; }
        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }
        [Required]
        public Transmission Transmission { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public Client Owner { get; set; }
        public List<Application> Applications { get; set; }
        public List<Image> Images { get; set; }

    }
}
