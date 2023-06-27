using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await _context.Brands.Include(b => b.Models).ToListAsync();
        }
    }
}
