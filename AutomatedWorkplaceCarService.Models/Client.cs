using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Client : User
    {
        [Required(ErrorMessage = "Поле 'Мобильный телефон' не может быть пустым!")]
        [RegularExpression(@"^\+[0-9]{11}$", ErrorMessage = "Пожалуйста, введите корректный номер телефона (Формат: +12223334455)")]
        [MaxLength(15)]
        public string MobilePhone { get; set; }
    }
}
