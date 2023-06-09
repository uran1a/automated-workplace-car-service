﻿using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.BLL.DTOs
{
    public class EmployeeDTO : UserDTO
    {
        public int PostId { get; set; }
        public PostDTO Post { get; set; }
        public List<ApplicationDTO> Applications { get; set; } = new();
    }
}
