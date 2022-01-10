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
    public class SpaceshipService : ISpaceshipService
    {
        private readonly WebShopDbContext _context;

        public SpaceshipService
            (
                WebShopDbContext context
            )
        {
            _context = context;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Name = dto.Name,
                Type = dto.Type,
                Mass = dto.Mass,
                Price = dto.Price,
                Crew = dto.Crew,
                ConstructedAt = dto.ConstructedAt,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt
            };

            await _context.Spaceship.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
