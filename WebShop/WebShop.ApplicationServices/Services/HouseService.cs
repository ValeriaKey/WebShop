using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;
using WebShop.Core.ServiceInterface;
using WebShop.Data;

namespace WebShop.ApplicationServices.Services
{
    public class HouseService : IHouseService
    {
        private readonly WebShopDbContext _context;

        public HouseService
            (
                WebShopDbContext context
            )
        {
            _context = context;
        }

        public async Task<House> Delete(Guid id)
        {
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }

        public async Task<House> Add(HouseDto dto)
        {
            House house = new House()
            {
                Id = dto.Id,
                Address = dto.Address,
                Floors = dto.Floors,
                Rooms = dto.Rooms,
                Price = dto.Price,
                Area = dto.Area,
                Color = dto.Color,
                ConstructedAt = dto.ConstructedAt,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt
            };

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }
        public async Task<House> Edit(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<House> Update(HouseDto dto)
        {
            House house = new House();

            house.Id = dto.Id;
            house.Address = dto.Address;
            house.Floors = dto.Floors;
            house.Rooms = dto.Rooms;
            house.Price = dto.Price;
            house.Area = dto.Area;
            house.Color = dto.Color;
            house.ConstructedAt = dto.ConstructedAt;
            house.CreatedAt = dto.CreatedAt;
            house.ModifiedAt = dto.ModifiedAt;

            _context.House.Update(house);
            await _context.SaveChangesAsync();

            return house;
        }

        // FOR TEST
     
        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
