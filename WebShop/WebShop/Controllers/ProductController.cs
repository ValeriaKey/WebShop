using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.Models.Product;

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


            return RedirectToAction(nameof(Index), null);
        }
    }
}
