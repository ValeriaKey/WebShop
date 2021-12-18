using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.Models.Car;

namespace WebShop.Controllers
{
    public class CarController : Controller
    {
            private readonly WebShopDbContext _context;
            private readonly ICarService _carService;

            public CarController
                (
                    WebShopDbContext context,
                    ICarService carService
                )
            {
                _context = context;
                _carService = carService;
            }


            public IActionResult Index()
            {
                var result = _context.Car
                    .Select(x => new CarListViewModel
                    {
                        Id = x.Id,
                        Brand = x.Brand,
                        Moodel = x.Moodel,
                        Price = x.Price,
                        Amount = x.Amount,
                        Description = x.Description
                    });

                return View(result);
            }
            [HttpPost]
            public async Task<IActionResult> Delete(Guid id)
            {
                var car = await _carService.Delete(id);


                return RedirectToAction(nameof(Index), null);
            }
        }
    }
