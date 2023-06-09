﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Employee : User
    {
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        public List<Application> Applications { get; set; } = new();
    }
}
