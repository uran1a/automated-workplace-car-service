using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatedWorkplaceCarService.Models
{
    public class User
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле 'Фамилия' не может быть пустым!")]
        [MaxLength(50), MinLength(2)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Поле 'Имя' не может быть пустым!")]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(50), MinLength(2)]
        public string? Patronymic { get; set; }
        [Required(ErrorMessage = "Поле 'Логин' не может быть пустым!")]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Поле 'Пароль' не может быть пустым!")]
        [MaxLength(50)]
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
