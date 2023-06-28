﻿using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.DTOs.Image;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _db;
        public CarService(IUnitOfWork uow)
        {
            _db = uow;
        }
        public async Task<CarDTO> Add(CreateCarDTO carDTO)
        {
            var newCar = _db.Cars.Add(Mapping.Mapper.Map<Car>(carDTO));
            await _db.SaveAsync();
            var car =  await _db.Cars.GetCarAsync(newCar.Id);
            return Mapping.Mapper.Map<CarDTO>(car);
        }

        public async Task<List<CarDTO>> GetAllCarsAsync()
        {
            var cars = await _db.Cars.GetAllCarsAsync();
            return Mapping.Mapper.Map<List<CarDTO>>(cars);
        }

        public async Task<CarDTO> GetCarAsync(int id)
        {
            return Mapping.Mapper.Map<CarDTO>(await _db.Cars.GetCarAsync(id));
        }
    }
}
