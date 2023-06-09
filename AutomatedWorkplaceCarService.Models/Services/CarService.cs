﻿using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CarService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CarDTO> Add(CreateCarDTO carDTO)
        {
            var newCar = _context.Cars.Add(_mapper.Map<Car>(carDTO));
            await _context.SaveChangesAsync();

            var car = await _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == newCar.Entity.Id);
            return _mapper.Map<CarDTO>(car);
        }

        public async Task<List<CarTableDTO>> GetCarsAsync(int ownerId)
        {
            var cars = await _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .Include(c => c.Owner)
                .Include(c => c.Applications)
                .Include(c => c.Images)
                .Where(c => c.OwnerId == ownerId).ToListAsync();
            return _mapper.Map<List<CarTableDTO>>(cars);
        }
        public async Task<List<CarDTO>> GetCars(int ownerId)
        {
            var cars = await _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .Include(c => c.Owner)
                .Include(c => c.Applications)
                .Include(c => c.Images)
                .Where(c => c.OwnerId == ownerId).ToListAsync();
            return _mapper.Map<List<CarDTO>>(cars);
        }

        public async Task<List<CarDTO>> GetAllCarsAsync()
        {
            var cars = await _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .Include(c => c.Owner)
                .Include(c => c.Applications)
                .Include(c => c.Images).ToListAsync();
            return _mapper.Map<List<CarDTO>>(cars);
        }

        public async Task<CarDTO> GetCarAsync(int id)
        {
            var car = await _context.Cars
               .Include(c => c.Model)
               .Include(c => c.Brand)
               .Include(c => c.Transmission)
               .Include(c => c.Images)
               .Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CarDTO>(car);
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return;
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<CarDTO> UpdateAsync(CarDTO cardDTO)
        {
            var newCar = _context.Cars.Update(_mapper.Map<Car>(cardDTO)); 
            await _context.SaveChangesAsync();
            var car = await _context.Cars
                 .Include(c => c.Model)
                 .Include(c => c.Brand)
                 .Include(c => c.Transmission)
                 .Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == newCar.Entity.Id);
            return _mapper.Map<CarDTO>(car);
        }
        public async Task<List<CarDTO>> SearchAsync(string searchTerm, int ownerId)
        {
            List<CarDTO> cars = await GetCars(ownerId);
            if (string.IsNullOrWhiteSpace(searchTerm)) return cars;
            return cars.Where(c => c.Model.Name.ToLower().Contains(searchTerm.ToLower()) || c.Brand.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
        }
    }
}
