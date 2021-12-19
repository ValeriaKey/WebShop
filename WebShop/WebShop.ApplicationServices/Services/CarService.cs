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
            var domain = new Car()
            {
                Id = dto.Id,
                Description = dto.Description,
                Brand = dto.Brand,
                Moodel = dto.Moodel,
                Amount = dto.Amount,
                Price = dto.Price,
                ModifiedAt = dto.ModifiedAt,
                CreatedAt = dto.CreatedAt
            };

            await _context.Car.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}