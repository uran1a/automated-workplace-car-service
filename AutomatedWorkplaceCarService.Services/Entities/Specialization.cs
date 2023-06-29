using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
