using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int? ApplicationId { get; set; }
        public Application? Application { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
    }
}
