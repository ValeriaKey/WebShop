using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.Models.Product;
using WebShop.Core.Dtos;
using WebShop.Core.Dtos.ProductDto;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebShopDbContext _context;
        private readonly IProductService _productService;

        public ProductController
            (
                WebShopDbContext context,
                IProductService productService
            )
        {
            _context = context;
            _productService = productService;
        }


        public IActionResult Index()
        {
            var result = _context.Product
                .Select(x => new ProductListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    Description = x.Description
                });

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.Delete(id);

            if (product == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductViewModel model = new ProductViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            var dto = new ProductDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt
            };

            var result = await _productService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }
    }
}
