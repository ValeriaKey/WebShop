using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.Dtos;
using WebShop.Core.Dtos.CarDto;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.Models.Car;
using WebShop.Models.Files;

namespace WebShop.Controllers
{
    public class CarController : Controller
    {
            private readonly WebShopDbContext _context;
            private readonly ICarService _carService;
            private readonly IFileServices _fileService;

        public CarController
                (
                    WebShopDbContext context,
                    ICarService carService,
                    IFileServices fileService
                )
            {
                _context = context;
                _carService = carService;
                _fileService = fileService;
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


            return RedirectToAction(nameof(Index));
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
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePathsForCar = model.ExistingFilePathsForCar
                    .Select(x => new ExistingFilePathForCarDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
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
            var car = await _carService.Edit(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.ExistingFilePathForCar.Where(x => x.CarId == id).Select(y => new ExistingFilePathForCarViewModel
            {
                FilePath = y.FilePath,
                PhotoId = y.Id
            })
               .ToArrayAsync();
            var model = new CarViewModel();

            model.Id = car.Id;
            model.Description = car.Description;
            model.Brand = car.Brand;
            model.Moodel = car.Moodel;
            model.Amount = car.Amount;
            model.Price = car.Price;
            model.ModifiedAt = car.ModifiedAt;
            model.CreatedAt = car.CreatedAt;
            model.ExistingFilePathsForCar.AddRange(photos);

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
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePathsForCar = model.ExistingFilePathsForCar
                    .Select(x => new ExistingFilePathForCarDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathForCarViewModel model)
        {
            var dto = new ExistingFilePathForCarDto()
            {
                FilePath = model.FilePath
            };

            var image = await _fileService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
    }
