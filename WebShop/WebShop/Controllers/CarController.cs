using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.Dtos.CarDto;
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


            if (car == null)
            {
                RedirectToAction(nameof(Index));
            }


            return RedirectToAction(nameof(Index), car);
            }

        [HttpGet]
        public IActionResult Add()
        {
            CarViewModel model = new CarViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarListViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                Description = model.Description,
                Brand = model.Brand,
                Moodel = model.Moodel,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt
            };

            var result = await _carService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _carService.Edit(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new CarViewModel();

            model.Id = product.Id;
            model.Description = product.Description;
            model.Brand = product.Brand;
            model.Moodel = product.Moodel;
            model.Amount = product.Amount;
            model.Price = product.Price;
            model.ModifiedAt = product.ModifiedAt;
            model.CreatedAt = product.CreatedAt;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                Description = model.Description,
                Brand = model.Brand,
                Moodel = model.Moodel,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt
            };

            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), model);
        }
    }
    }
