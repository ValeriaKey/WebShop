using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos.ProductDto;
using WebShop.Core.ServiceInterface;
using WebShop.Data;

namespace WebShop.ApplicationServices.Services
{
    public class ProductServices : IProductService
    {
        private readonly WebShopDbContext _context;

        public ProductServices
            (
                WebShopDbContext context
            )
        {
            _context = context;
        }

        public async Task<Product> Delete(Guid id)
        {
            var productId = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }
<<<<<<< HEAD
=======

        public async Task<Product> Add(ProductDto dto)
        {
            var domain = new Product()
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                Amount = dto.Amount,
                Price = dto.Price,
                ModifiedAt = dto.ModifiedAt,
                CreatedAt = dto.CreatedAt
            };

            await _context.Product.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

>>>>>>> master
    }
}