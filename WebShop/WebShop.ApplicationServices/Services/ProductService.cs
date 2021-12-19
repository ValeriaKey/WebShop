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

<<<<<<< HEAD
=======
        }

>>>>>>> 78022f2 (EditAndUpdateProduct ( Controller ))
        public async Task<Product> Add(ProductDto dto)
        {
            Product product = new Product();

            product.Id = dto.Id;
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Amount = dto.Amount;
            product.Price = dto.Price;
            product.ModifiedAt = DateTime.Now;
            product.CreatedAt = DateTime.Now;

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Edit(Guid id)
        {
            var result = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Product> Update(ProductDto dto)
        {
            Product product = new Product();

            product.Id = dto.Id;
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Amount = dto.Amount;
            product.Price = dto.Price;
            product.ModifiedAt = dto.ModifiedAt;
            product.CreatedAt = dto.CreatedAt;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}