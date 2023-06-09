﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Model> Models { get; set; } = new();
    }
}
