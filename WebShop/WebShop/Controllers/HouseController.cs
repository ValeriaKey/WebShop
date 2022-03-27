using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.Dtos;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.Models.House;
using WebShop.Models.Spaceship;

namespace WebShop.Controllers
{
    public class HouseController : Controller
    {
        private readonly WebShopDbContext _context;
        private readonly IHouseService _houseService;

        public HouseController
            (
                WebShopDbContext context,
                IHouseService housepService
            )
        {
            _context = context;
            _houseService = housepService;
        }

        public IActionResult Index()
        {
            var result = _context.House
                 .Select(x => new HouseListViewModel
                 {
                     Id = x.Id,
                     Address = x.Address,
                     Rooms = x.Rooms,
                     Floors = x.Floors,
                     Price = x.Price,
                     Area = x.Area,
                     Color = x.Color,
                     ConstructedAt = x.ConstructedAt
                 });

            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);

            if (house == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), house);
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();

            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(HouseListViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Address = model.Address,
                Floors = model.Floors,
                Rooms = model.Rooms,
                Price = model.Price,
                Area = model.Area,
                Color = model.Color,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _houseService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.Edit(id);

            if (house == null)
            {
                return NotFound();
            }

            var model = new HouseViewModel();

            model.Id = house.Id;
            model.Address = house.Address;
            model.Floors = house.Floors;
            model.Rooms = house.Rooms;
            model.Price = house.Price;
            model.Area = house.Area;
            model.Color = house.Color;
            model.ConstructedAt = house.ConstructedAt;
            model.CreatedAt = house.CreatedAt;
            model.ModifiedAt = house.ModifiedAt;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Address = model.Address,
                Floors = model.Floors,
                Rooms = model.Rooms,
                Price = model.Price,
                Area = model.Area,
                Color = model.Color,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }
    }
}