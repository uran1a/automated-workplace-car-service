﻿namespace AutomatedWorkplaceCarService.WEB.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
