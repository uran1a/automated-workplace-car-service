using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50), MinLength(2)]
        public string Surname { get; set; }
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(50), MinLength(2)]
        public string? Patronymic { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
