using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ContentType { get; set; }
        [Required]
        public byte[] Content { get; set; } 
        public int? ApplicationId { get; set; }
        public Application? Application { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }

    }
}
