using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;
using WebShop.Core.Dtos.CarDto;
using WebShop.Core.Dtos.ProductDto;
using WebShop.Core.ServiceInterface;
using WebShop.Data;

namespace WebShop.ApplicationServices.Services
{
    public class CarService : ICarService
    {
        private readonly WebShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileServices _file;

        public CarService
            (
                WebShopDbContext context,
                IWebHostEnvironment env,
                IFileServices file
            )
        {
            _context = context;
            _env = env;
            _file = file;
        }

        public async Task<Car> Delete(Guid id)
        {
            var photos = await _context.ExistingFilePathForCar
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathForCarDto
                {
                    CarId = y.CarId,
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();

            var carId = await _context.Car
                .Include(x => x.ExistingFilePathsForCar)
                .FirstOrDefaultAsync(x => x.Id == id);
            await _file.RemoveImages(photos);

            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }


        public async Task<Car> Add(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.Description = dto.Description;
            car.Brand = dto.Brand;
            car.Moodel = dto.Moodel;
            car.Amount = dto.Amount;
            car.Price = dto.Price;
            car.ModifiedAt = DateTime.Now;
            car.CreatedAt = DateTime.Now;
            _file.ProcessUploadedFile(dto, car);

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
            _file.ProcessUploadedFile(dto, car);

            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        
    }
}