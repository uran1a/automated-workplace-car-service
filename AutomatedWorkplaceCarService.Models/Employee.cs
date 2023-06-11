﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Models
{
    public class Employee : User
    {
        public Post? Post { get; set; }
        public List<Application> Applications { get; set; }
    }
}
