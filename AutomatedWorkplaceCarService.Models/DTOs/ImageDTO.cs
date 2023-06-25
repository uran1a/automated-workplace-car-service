using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int? ApplicationId { get; set; }
        public ApplicationDTO? Application { get; set; }
        public int? CarId { get; set; }
        public CarDTO? Car { get; set; }
    }
}
