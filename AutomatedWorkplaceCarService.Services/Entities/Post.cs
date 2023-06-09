﻿using System.ComponentModel.DataAnnotations;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new();
        public List<Specialization> Specializations { get; set; } = new();
    }
}
