using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos.CarDto;
using WebShop.Core.Dtos.ProductDto;
using WebShop.Core.ServiceInterface;
using WebShop.Data;

namespace WebShop.ApplicationServices.Services
{
    public class CarService : ICarService
    {
        private readonly WebShopDbContext _context;

        public CarService
            (
                WebShopDbContext context
            )
        {
            _context = context;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }


        public async Task<Car> Add(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Description = dto.Description;
            car.Brand = dto.Brand;
            car.Moodel = dto.Moodel;
            car.Amount = dto.Amount;
            car.Price = dto.Price;
            car.ModifiedAt = DateTime.Now;
            car.CreatedAt = DateTime.Now;

            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Edit(Guid id)
        {
            var result = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Description = dto.Description;
            car.Brand = dto.Brand;
            car.Moodel = dto.Moodel;
            car.Amount = dto.Amount;
            car.Price = dto.Price;
            car.ModifiedAt = dto.ModifiedAt;
            car.CreatedAt = dto.CreatedAt;

            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}