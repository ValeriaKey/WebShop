using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models.Product;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebShopDbContext _context;

        public ProductController
            (
                WebShopDbContext context
            )
        {
            _context = context;
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
    }
}
