using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Authentication
    {
        [Required(ErrorMessage = "Поле 'Логин' не может быть пустым!")]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Поле 'Пароль' не может быть пустым!")]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
