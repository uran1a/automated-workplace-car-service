using AutomatedWorkplaceCarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Services
{
    public class SqlApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        public SqlApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
