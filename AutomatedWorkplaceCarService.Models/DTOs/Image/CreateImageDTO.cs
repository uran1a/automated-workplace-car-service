using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs.Image
{
    public class CreateImageDTO
    {
        public string FullName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int? ApplicationId { get; set; }
        public int? CarId { get; set; }
    }
}
